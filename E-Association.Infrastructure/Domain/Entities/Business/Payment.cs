using Domain.Entities.Securities;
using E_Association.Core.Domain.Enums;

namespace Domain.Entities.Business
{
    public class Payment
    {
        public Guid Id { set; get; }
        public decimal Amount { set; get; }
        public PaymentStatus Status { set; get; }
        public DateTime PaidAt { set; get; }
        public Guid ?UserId { set; get; }
        public Guid ?AssociationId { set; get; }
        public Consumer ?User { set; get; }
        public Association ?Association { set; get; }
    }
}
