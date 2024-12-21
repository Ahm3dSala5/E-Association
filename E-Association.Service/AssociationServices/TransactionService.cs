using Domain.Entities.Business;
using E_Association.Core.Domain.Enums;
using E_Association.Infrastructure.Domain.DTOs.Transactions;
using E_Association.Infrastructure.Presitence.Data;
using E_Association.Service.IAssociationServices.Userservice;
using Microsoft.EntityFrameworkCore;

namespace E_Association.Service.AssociationServices.Userservice
{
    public class TransactionService : ITransactionService
    {
        private AppDbContext _app;
        private DbSet<Transactions> _transaction;
        public TransactionService(AppDbContext app)
        {
            _app = app;
            _transaction = app.Set<Transactions>();
        }

        public async ValueTask<List<Transactions>> GetUserTransaction(Guid userId)
        {
            if (userId == Guid.Empty)
                throw new ArgumentNullException("Invalid Data");

            var user = await _app.users.FindAsync(userId);
            if (user is null)
                throw new ArgumentNullException("User not found");
            return user.Transactions.ToList();
        }
        public async ValueTask<string> StartTransaction(TransactionDTO transaction)
        {
            if (transaction is null)
                throw new ArgumentNullException("Invalid Data");

            var user = await _app.users.FindAsync(transaction.UserId);
            if (user is null)
                throw new ArgumentNullException("User not found");

            if (transaction.BalancePassword != user.Balance.Password)
                throw new Exception("Invalid Balance Passwsord");

            var transactionResult = 0;
            if(transaction.state is TransactionState.Withdrawal)
            {
                if (transaction.Amount > user.Balance.Amount)
                    throw new Exception("User Not Have enough Money");

                using (var _transaction = await _app.Database.BeginTransactionAsync())
                {
                    user.Balance.Amount -= transaction.Amount;
                    await _transaction.CommitAsync();
                    transactionResult = await _app.SaveChangesAsync();
                }

                return transactionResult > 0 ? "Withdrawal Successeded" : "Invalid Withdrawal";
            }

            using (var _transaction = await _app.Database.BeginTransactionAsync())
            {
                user.Balance.Amount -= transaction.Amount;
                await _transaction.CommitAsync();
                transactionResult = await _app.SaveChangesAsync();
            }

            return transactionResult > 0 ? "Deposit Successeded" : "Invalid Deposit";
        }
        public async ValueTask<string> CreateAsync(Transactions entity)
        {
            if (entity is null)
                throw new ArgumentNullException("Invalid Data");

            await _transaction.AddAsync(entity);
            int creation = _app.SaveChanges();
            return creation > 0 ? "Created Successfuly" : "Invalid Creation";
        }

        public async ValueTask<string> DeletAsync(Guid entityId)
        {
            if (entityId == Guid.Empty)
                throw new ArgumentNullException("Invalid Data");

            var entity = await _transaction.FindAsync(entityId);
            if (entity is null)
                throw new ArgumentNullException("Entity Not Found");

            _transaction.Remove(entity);
            int deletion = _app.SaveChanges();
            return deletion > 0 ? "deleted Successfuly" : "Invalid deleting";
        }

        public async ValueTask<List<Transactions>> GetAllAsync()
        {
            var entities = await _transaction.ToListAsync();
            if (entities is null)
                throw new ArgumentNullException("Entity Not Found");

            return entities;

        }

        public async ValueTask<Transactions> GetOneByIdAsync(Guid id)
        {
            var entity = await _transaction.FindAsync(id);
            if (entity is null)
                throw new ArgumentNullException("Entity Not Found");

            return entity;
        }

        public async ValueTask<string> UpdateAsync(Transactions entity)
        {
            if (entity is null)
                throw new ArgumentNullException("Invalid Data");

            _transaction.Attach(entity);
            int creation = await _app.SaveChangesAsync();
            return creation > 0 ? "Created Successfuly" : "Invalid Creation";
        }
    }
}