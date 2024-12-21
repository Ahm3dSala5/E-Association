namespace E_Association.Core.Features.Balances.Query.Models
{
    public class BalanceDetailsDTO
    {
        public Guid Id { set; get; }
        public decimal Amount { set; get; }
        public decimal Deposit { set; get; }
        public decimal Withdrawal { set; get; }
        public DateTime CreatedAt { set; get; }
        public Guid UserId { get; set; }
    }
}
