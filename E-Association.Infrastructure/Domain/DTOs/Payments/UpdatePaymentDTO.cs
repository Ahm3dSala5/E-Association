namespace E_Association.Infrastructure.Domain.DTOs.Payments
{
    public class UpdatePaymentDTO
    {
        public Guid UserId { set; get; }
        public Guid AssociationId { set; get; }
        public Guid PaymentId { set; get; }
        public decimal Amount { set; get; }
    }
}
