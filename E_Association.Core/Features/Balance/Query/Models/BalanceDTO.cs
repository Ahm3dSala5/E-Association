namespace E_Association.Core.Features.Balances.Query.Models
{
    public class BalanceDTO
    {
        public decimal Amount { set; get; }
        public DateTime CreatedAt { set; get; }
        public Guid UserId { get; set; }
    }
}
