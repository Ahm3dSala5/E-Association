using E_Association.Infrastructure.Domain.DTOs.Payments;
using MediatR;

namespace E_Association.Core.Features.Payments.Command.Request
{
    public class UpdatePaymentCommand :IRequest<string>
    {
        public UpdatePaymentCommand(UpdatePaymentDTO _payment)
        {
            this.PaymentId =_payment.PaymentId;
            this.UserId = _payment.UserId;
            this.Amount = _payment.Amount;
            this.AssociationId = _payment.AssociationId;    
        }
        public Guid UserId { set; get; }
        public Guid AssociationId { set; get; }
        public Guid PaymentId { set; get; }
        public decimal Amount { set; get; }
    }
}
