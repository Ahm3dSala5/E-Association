using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Association.Core.Features.Transactions.Queries.Model
{
    public class TransactionModel
    {
        public Guid Id { set; get; } = new Guid();
        public decimal Salary { set; get; }
        public DateTime StartedAt { set; get; }
        public Guid? UserId { set; get; }
        public Guid BalanceId { set; get; }
    }
}
