using Domain.Entities.Business;
using E_Association.Infrastructure.Presitence.Data;
using E_Association.Service.IAssociationServices.IBalanceServices;
using Microsoft.EntityFrameworkCore;

namespace E_Association.Service.AssociationServices.BalanceServices
{
    public class BalanceServices : IBalanceServices
    {
        private readonly AppDbContext _app;

        public BalanceServices(AppDbContext app)
        {
            _app = app;
        }

        public async ValueTask<string> DeleteUserBalance(Guid userId)
        {
            if(string.IsNullOrEmpty(userId.ToString()))
                throw new Exception("Invalid Balance Number");

            var user = await  _app.users.SingleOrDefaultAsync(x => x.Id == userId);
            if (user is null)
                throw new Exception("User Balance Not Found");

            user.Balance.Amount = 0;
            int deletion = _app.SaveChanges();

            return deletion > 0 ? "User Balance jas Been Reset to default"
                                  :"Invalid deletions";
        }

        public async ValueTask<Balance> GetBalanceDetails(Guid balanceId)
        {
            if (string.IsNullOrEmpty(balanceId.ToString()))
                throw new Exception("Invalid Balance Number");

            var balance = await _app.Balances.SingleOrDefaultAsync(x=>x.Id == balanceId);
            if (balance is null)
                throw new Exception("Balance Not found");
            return balance;
        }

        public async ValueTask<List<Transactions>> GetBalanceTransactions(Guid balanceId)
        {
            if (string.IsNullOrEmpty(balanceId.ToString()))
                throw new Exception("Invalid Balance Number");

            var balance = await _app.Balances.Include(x=>x.Transactions).SingleOrDefaultAsync(x => x.Id == balanceId);
            if (balance is null)
                throw new Exception("Balance Not found");

            var transactions = balance.Transactions.ToList();
            return transactions;
        }

        public async ValueTask<Balance> GetUserBalance(Guid userId)
        {
            if (string.IsNullOrEmpty(userId.ToString()))
                throw new Exception("Invalid Balance Number");


            var user = _app.users.Include(x => x.Balance).SingleOrDefault(x=>x.Id == userId);
            if (user is null)
                throw new Exception("Balance Not found");

            return user.Balance;
        }

        public async ValueTask<string> UpdateUserPalanceAsync(Balance newBalance)
        {
            if (newBalance is null)
                throw new Exception("Invalid Data");
            
            var balance = await _app.Balances.SingleOrDefaultAsync(x => x.Id == newBalance.Id);
            if (balance is null)
                throw new Exception("Balance Not found");

            _app.Balances.Update(newBalance);
            int creation = _app.SaveChanges();
            return  creation > 0 ? "Update Successfuly" : "Invalid Creation";

        }
        public async ValueTask<string> CreateBalanceAsync(Balance balance)
        {
            if (balance is null)
                throw new ArgumentException("Invalid Data");

            await _app.Balances.AddAsync(balance);
            var creation = _app.SaveChanges();
            return creation > 0 ? "Created Successfuly": "Invalid Creation";
        }
    }
}
