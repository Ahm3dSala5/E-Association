using Domain.Entities.Securities;

namespace Domain.Entities.Business
{
    public class Deposit
    {
        public Guid Id { set; get; }
        public decimal Amount { set; get; }
        public DateTime DepositedAt { set; get; }
        public Guid UserId { set; get; }
        public Balance Balance { set; get; }
        public Guid BalanceId { set; get; }
        public ApplicationUser User { set; get; }
    }
}
