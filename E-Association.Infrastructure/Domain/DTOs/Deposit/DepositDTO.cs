namespace E_Association.Infrastructure.Domain.DTOs.Deposit
{
    public class DepositDTO
    {
        public Guid userId { set; get; }
        public DateTime DepositAt { set; get; }
        public decimal Amount { set; get; }
    }
}

