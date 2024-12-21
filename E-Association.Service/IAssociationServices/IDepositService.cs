using Domain.Entities.Business;

namespace E_Association.Service.IAssociationServices.Userservice
{
    public interface IDepositService
    {
        ValueTask<string> StartDeposit(Guid userId ,decimal amount);
        ValueTask<string> DeleteDeposit(Guid depositeId);
        ValueTask<string> UpdateDeposit(Guid userId, decimal newAmoutt,Guid depositId);
        ValueTask<List<Deposit>> GetUserDeposits(string userName);
        ValueTask<Deposit> GetDepositDetails(Guid depositId);
        ValueTask<List<Deposit>> GetAllDeposits();
    }
}
