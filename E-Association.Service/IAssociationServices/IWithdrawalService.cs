using Domain.Entities.Business;

namespace E_Association.Service.IAssociationServices.Userservice
{
    public interface IWithdrawalService
    {
        ValueTask<string> StartWithdrawal(Guid userId,decimal amount);
        ValueTask<string> Updatewithdrwals(Withdrawals withdrawal);
        ValueTask<string> CalncelationWithdrawal(Guid withdrwals);
        ValueTask<List<Withdrawals>> GetUserWithdrawals(Guid userId);
        ValueTask<Withdrawals> GetWithdrawalDetails(Guid withdrwalsId);
        ValueTask<List<Withdrawals>> GetAllWithdrawals();
    }
}
