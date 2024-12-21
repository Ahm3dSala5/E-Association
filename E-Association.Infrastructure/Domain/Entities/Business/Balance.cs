using Domain.Entities.Securities;

namespace Domain.Entities.Business
{
    public class Balance
    {
        public Guid Id { set; get; }
        public decimal Amount { set; get; }
        public string Password { set; get; }
        public DateTime CreatedAt { set; get; }
        public Guid ? UserId { get; set; }
        public Consumer ?User { set; get; }

        public ICollection<Withdrawals> Withdrawals = new List<Withdrawals>();

        public ICollection<Deposit> Deposits = new List<Deposit>();
        public ICollection<Transactions> Transactions { set; get; } = new List<Transactions>();
    }
}
