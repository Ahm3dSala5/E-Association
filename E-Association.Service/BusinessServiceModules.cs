using E_Association.Service.AssociationServices.BalanceServices;
using E_Association.Service.AssociationServices.EmailService;
using E_Association.Service.AssociationServices.Userservice;
using E_Association.Service.IAssociationServices.IBalanceServices;
using E_Association.Service.IAssociationServices.IEmailSender;
using E_Association.Service.IAssociationServices.Userservice;
using E_Association.Service.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;

namespace E_Association.Service
{
    public static class BusinessServiceModules
    {
        public static void AddBusinessServicesModules(this IServiceCollection service)
        {
            service.AddTransient(typeof(IMainService<>) ,typeof(MainService<>));
            service.AddTransient<IAuthorizationService, AuthorizationService>();
            service.AddTransient<IAuthenticationService, AuthonticationService>();
            service.AddTransient<IConsumerService, ConsumerService>();
            service.AddTransient<IEmailSender, EmailSender>();
            service.AddTransient<IUnitOfWork, UnitOfWork>();

            service.AddTransient<IPaymentService, PaymentService>();
            service.AddTransient<IAssociationService, AssociationService>();
            service.AddTransient<IBalanceServices, BalanceServices>();
            service.AddTransient<INotificationService, NotificationService>();
            service.AddTransient<IWithdrawalService, WithdrawalService>();
            service.AddTransient<IDepositService, DepositService>();
            service.AddTransient<ITransactionService, TransactionService>();
        }
    }
}
