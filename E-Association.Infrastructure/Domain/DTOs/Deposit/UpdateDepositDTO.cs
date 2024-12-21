namespace E_Association.Infrastructure.Domain.DTOs.Deposit
{
    public class UpdateDepositDTO
    {
        public Guid userId { set; get; }
        public Guid depositId { set; get; }
        public decimal Amount { set; get; }
        
    }
}

