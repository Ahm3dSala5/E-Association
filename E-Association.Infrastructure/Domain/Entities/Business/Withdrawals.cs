using Domain.Entities.Securities;
using E_Association.Core.Domain.Enums;
namespace Domain.Entities.Business
{
    public class Withdrawals
    {
        public Guid Id { set; get; }
        public decimal Amount { set; get; }
        public WithdrawalsStatus Status { set; get; }
        public DateTime WithdrawalAt { set; get; }
        public Guid ?UserId { set; get; }
        public ApplicationUser ?ApplicationUser { set; get; }
        public Balance Balance { set; get; }
        public Guid BalanceId { set; get; }
    }
}
