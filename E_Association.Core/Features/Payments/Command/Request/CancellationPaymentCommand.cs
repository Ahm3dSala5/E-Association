using MediatR;

namespace E_Association.Core.Features.Payments.Command.Request
{
    public class CancellationPaymentCommand : IRequest<string>
    {
        public CancellationPaymentCommand(Guid _paymentId)
        {
            this.PaymentId = _paymentId;
        }
        public Guid PaymentId { set; get; }
    }
}
