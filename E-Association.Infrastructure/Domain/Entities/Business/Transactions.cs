using Domain.Entities.Securities;

namespace Domain.Entities.Business
{
    public class Transactions
    {
        public Guid Id { set; get; } = new Guid();
        public decimal Salary { set; get; }
        public DateTime StartedAt { set; get; }
        public Guid ?UserId { set; get; }
        public Guid ?BalanceId { set; get; }
        public Balance ? Balance { set; get; }
        public Consumer? User { set; get; }
    }
}
