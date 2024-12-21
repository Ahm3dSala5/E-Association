using E_Association.Core.Domain.Enums;
using MediatR;

namespace E_Association.Core.Features.Payments.Query.Model
{
    public class PaymentModel
    {
        public Guid Id { set; get; }
        public decimal Amount { set; get; }
        public PaymentStatus Status { set; get; }
        public DateTime PaidAt { set; get; }
        public Guid? UserId { set; get; }
        public Guid? AssociationId { set; get; }
    }
}
