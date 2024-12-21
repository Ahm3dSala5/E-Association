using E_Association.Infrastructure.Presitence.Data;
using E_Association.Service.AssociationServices.BalanceServices;
using E_Association.Service.AssociationServices.Userservice;
using E_Association.Service.IAssociationServices.IBalanceServices;
using E_Association.Service.IAssociationServices.Userservice;

namespace E_Association.Service.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _app;
        public UnitOfWork(AppDbContext app)
        {
            _app = app;
            this.NotificationService = new NotificationService(_app);
            this.BalanceServic = new BalanceServices(_app);
            this.WithdrawalsService = new WithdrawalService(_app);
            this.Transaction = new TransactionService(app);
            this.Patment = new PaymentService(app);
            this.Deposit = new DepositService(_app);
        }

        public IBalanceServices BalanceServic { get; private set; }

        public INotificationService NotificationService { get; private set; }

        public IWithdrawalService WithdrawalsService  { get; private set; }


        public ITransactionService Transaction { get; private set; }

        public IPaymentService Patment { get; private set; }

        public IDepositService Deposit { get; private set; }

        public async Task <int> commit()
        {
            return await _app.SaveChangesAsync();
        }

        public async void Dispose()
        {
            await _app.DisposeAsync();
        }
    }
}
