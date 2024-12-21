using E_Association.Core.Domain.Enums;

namespace E_Association.Infrastructure.Domain.DTOs.Transactions
{
    public class TransactionDTO
    {
        public Guid UserId { get; set; }
        public Guid BalanecId { set; get; }
        public string BalancePassword { set; get; }
        public decimal Amount { set; get; }
        public  TransactionState state  { set;get; }

    }
}
