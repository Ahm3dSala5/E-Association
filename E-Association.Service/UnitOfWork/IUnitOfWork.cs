using E_Association.Service.IAssociationServices.IBalanceServices;
using E_Association.Service.IAssociationServices.Userservice;

namespace E_Association.Service.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
    
        ITransactionService  Transaction {get;}
        IDepositService Deposit { get; }
        IPaymentService Patment { get; }
        IBalanceServices BalanceServic { get; }
        INotificationService NotificationService {get; }
        IWithdrawalService WithdrawalsService { get; }
        Task<int> commit();
    }
}
