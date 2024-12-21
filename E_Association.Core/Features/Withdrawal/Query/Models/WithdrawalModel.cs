using E_Association.Core.Domain.Enums;

namespace E_Association.Core.Features.Withdrawal.Query.Models
{
    public class WithdrawalModel
    {
        public Guid Id { set; get; }
        public decimal Amount { set; get; }
        public WithdrawalsStatus Status { set; get; }
        public DateTime WithdrawalAt { set; get; }
        public Guid? UserId { set; get; }
    }
}
