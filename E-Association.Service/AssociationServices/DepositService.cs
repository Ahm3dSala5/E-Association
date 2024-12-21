using Domain.Entities.Business;
using E_Association.Infrastructure.Presitence.Data;
using E_Association.Service.IAssociationServices.Userservice;
using Microsoft.EntityFrameworkCore;

namespace E_Association.Service.AssociationServices.Userservice
{
    public class DepositService  : IDepositService
    {
        private AppDbContext _app;
       public DepositService(AppDbContext app)
       {
            this._app = app;
       }

        public async ValueTask<string> DeleteDeposit(Guid depositeId)
        {
            if (depositeId == Guid.Empty)
                throw new ArgumentNullException("Invalid Data");

            var deposit = await _app.Deposits.FindAsync(depositeId);
            if (deposit is null)
                throw new Exception("Deposit Not Found");
           
            int deletion = 0;
            _app.Deposits.Remove(deposit);
            deletion = await _app.SaveChangesAsync();
            return deletion > 0 ? "Successfuly" : "Invalid Operation";
        }

        public async ValueTask<List<Deposit>> GetAllDeposits()
        {
            var deposits = await _app.Deposits.ToListAsync();
            if(deposits is null)
                    throw new Exception("Deposits List is Empty");

            return deposits;
        }

        public async ValueTask<Deposit> GetDepositDetails(Guid depositId)
        {
            if (depositId == Guid.Empty)
                throw new ArgumentNullException("Invalid Data");

            var deposit = await _app.Deposits.FindAsync(depositId);
            if (deposit is null)
                
                throw new Exception("Deposit Not Found");
            return deposit;
        }

        public async ValueTask<List<Deposit>> GetUserDeposits(string userName)
        {
            if (userName is null)
                throw new ArgumentNullException("Invalid Data");

            var user = await _app.users.Include(x=>x.Deposites).SingleOrDefaultAsync(x=>x.UserName == userName);
            if (user is null)
                throw new Exception("User Not Found");

            var userDeposits = user.Deposites.ToList();
            if (userDeposits is null)
                throw new Exception("User Not Has Any Deposits");

            return userDeposits;
        }

        public async ValueTask<string> StartDeposit(Guid userId, decimal amount)
        {
            if (userId == Guid.Empty || amount <= 0)
                throw new ArgumentNullException("Invalid Data");

            var user = await _app.users.Include(x => x.Balance).SingleOrDefaultAsync(x=>x.Id == userId);
            if (user is null)
                throw new Exception("User Not Found");

            int startdeposit = 0;
            using (var transaction = await _app.Database.BeginTransactionAsync())
            {
                var deposit = new Deposit()
                {
                    Amount = amount,
                    UserId = userId,
                    DepositedAt = DateTime.UtcNow
                };
                user.Balance.Amount += amount;
                await _app.Deposits.AddAsync(deposit);
                await transaction.CommitAsync();
                startdeposit = await _app.SaveChangesAsync();
            }
            return  startdeposit > 0 ? "Successfuly" : "Invalid Operation";

        }

        public async ValueTask<string> UpdateDeposit(Guid userId, decimal newAmount , Guid DepositId)
        {
            if (userId == Guid.Empty || newAmount <= 0)
                throw new ArgumentNullException("Invalid Data");

            var user = await _app.users.Include(x => x.Balance).SingleOrDefaultAsync(x => x.Id == userId);
            if (user is null)
                throw new Exception("User Not Found");

            var deposit = user.Deposites.FirstOrDefault(x=>x.Id == DepositId);
            if (deposit is null)
                throw new Exception("deposit Not Found");

            int Update = 0;
            using (var transaction = await _app.Database.BeginTransactionAsync())
            {
                deposit.Amount = newAmount;
                await transaction.CommitAsync();
                Update = await _app.SaveChangesAsync();
            }
            return Update > 0 ? "Successfuly" : "Invalid Operation";
        }
    }
}