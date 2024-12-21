using MediatR;

namespace E_Association.Core.Features.Payments.Command.Request
{
    public class StartPaymentCommand :IRequest<string>
    {
        public StartPaymentCommand(Guid userId, decimal amount, Guid associationId)
        {
            this.userId = userId;
            this.amount = amount;
            this.associationId = associationId;
        }
        public Guid userId { set; get; }
        public Guid associationId { set; get; }
        public decimal amount { set; get; }
    }
}
