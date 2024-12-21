using Domain.Entities.Business;
using E_Association.Core.Features.Deposit.Commands.Request;
using E_Association.Core.Features.Payments.Command.Request;

namespace E_Association.Core.Mapping.Payments
{
    public partial class PaymentProfile 
    {
        public void AddStartPaymentMapping()
        {
            CreateMap<Payment,StartPaymentCommand>();
        }

        public void AddUpdatePaymentMapping()
        {
            CreateMap<Payment,UpdatePaymentCommand>();
        }

        public void AddCancellationPaymentMapping()
        {
            CreateMap<Payment,CancellationPaymentCommand>();
        }
    }
}
