using E_Association.Core.Domain.Enums;

namespace E_Association.Infrastructure.Domain.DTOs.Withdrawal
{
    public class WithdrawalDTO
    {
        public decimal Amount { set; get; }
        public WithdrawalsStatus Status { set; get; }
        public DateTime WithdrawalAt { set; get; }
        public Guid? UserId { set; get; }
    }

}
