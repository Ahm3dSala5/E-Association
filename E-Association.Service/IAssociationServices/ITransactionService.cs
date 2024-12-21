using Domain.Entities.Business;
using E_Association.Infrastructure.Domain.DTOs.Transactions;

namespace E_Association.Service.IAssociationServices.Userservice
{
    public interface ITransactionService
    {
        ValueTask<string> StartTransaction(TransactionDTO transaction);
        ValueTask<List<Transactions>> GetUserTransaction(Guid userId);
        ValueTask<string> UpdateAsync(Transactions entity);
        ValueTask<string> DeletAsync(Guid entityId);
        ValueTask<List<Transactions>> GetAllAsync();
        ValueTask<Transactions> GetOneByIdAsync(Guid id);
    }
      

    
}