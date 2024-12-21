using Domain.Entities.Business;
using E_Association.Infrastructure.Presitence.Data;
using E_Association.Service.IAssociationServices.Userservice;
using Microsoft.EntityFrameworkCore;

namespace E_Association.Service.AssociationServices.Userservice
{
    public class WithdrawalService : IWithdrawalService
    {
        private readonly AppDbContext _app;
        public WithdrawalService(AppDbContext app)
        {
            this._app = app;
        }

        public async ValueTask<string> CalncelationWithdrawal(Guid withdrwalsId)
        {
            if (withdrwalsId == Guid.Empty)
                throw new ArgumentNullException("Invalid Data");

            var withdrawal = await _app.Withdrawals.FindAsync(withdrwalsId);
            if (withdrawal is null)
                throw new ArgumentNullException("Withdrawal Not Found");
            
            _app.Withdrawals.Remove(withdrawal);
            var deletion = _app.SaveChanges();
            return deletion > 0 ?"Canceled Successfuly":"Invalid Cancelation";
        }

        public async ValueTask<List<Withdrawals>> GetAllWithdrawals()
        {
            var withdrawals = await _app.Withdrawals.ToListAsync();
           
            if (withdrawals is null)
                throw new ArgumentNullException("Withdrawals list is Empty");
            return withdrawals;
        }

        public async ValueTask<List<Withdrawals>> GetUserWithdrawals(Guid userId)
        {
            if (userId == Guid.Empty)
                throw new ArgumentNullException("Invalid Data");

            var user = await _app.users.FindAsync(userId);
            if (user is null)
                throw new ArgumentNullException("User Not Found");
           
            var withdrawals = user.Withdrawals;
            if(withdrawals is null)
                throw new ArgumentNullException("User Not Have any withdrwals");
               
            return withdrawals.ToList();
        }

        public async ValueTask<Withdrawals> GetWithdrawalDetails(Guid withdrwalsId)
        {
            if (withdrwalsId == Guid.Empty)
                throw new ArgumentNullException("Invalid Data");

            var withdrawal = await _app.Withdrawals.FindAsync(withdrwalsId);
            if (withdrawal is null)
                throw new ArgumentNullException("Invalid Withdrawal Number");
            
            return withdrawal;
        }

        public async ValueTask<string> StartWithdrawal(Guid userId,decimal amount)
        {
            if (userId == Guid.Empty || amount <=0 )
                throw new ArgumentNullException("Invalid Data");
             
            var user = await _app.users.FindAsync(userId);
            if (user is null)
                throw new ArgumentNullException("User Not Found");
           
            var userBalance = user.Balance.Amount;
            if(userBalance < amount)
                throw new ArgumentNullException("User not has enough Money");

            var withdrawalOperation = 0;
            using (var transaction = await _app.Database.BeginTransactionAsync())
            {
                user.Balance.Amount -= amount;
                await transaction.CommitAsync();
                withdrawalOperation =  _app.SaveChanges();
            }
            return withdrawalOperation > 0 ? "Withdrawal Successfuly" : "Invalid Withdrawal";
        }

        public async ValueTask<string> Updatewithdrwals(Withdrawals newWithdrawal)
        {

            if (newWithdrawal is null)
                throw new ArgumentNullException("Invalid Data");

            var oldWithdrawal = await _app.Withdrawals.FindAsync(newWithdrawal.Id);
            if (oldWithdrawal is null)
                throw new ArgumentNullException("Withdrawal Not found");

            _app.Withdrawals.Attach(newWithdrawal);
            int updatign = _app.SaveChanges();
            return updatign > 0 ? "Updated Successfuly" : "Invalid Update";
        }
    }
}