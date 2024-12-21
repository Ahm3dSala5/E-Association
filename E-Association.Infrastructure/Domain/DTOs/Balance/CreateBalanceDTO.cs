namespace E_Association.Infrastructure.Domain.DTOs
{
    public class CreateBalanceDTO
    {
        public decimal Amount { set; get; }
        public DateTime CreatedAt { set; get; }
        public Guid UserId { get; set; }
    }
}