using E_Association.Core.Features.Balances.Query.Models;
using MediatR;

namespace E_Association.Core.Features.Balances.Query.Request
{
    public class GetBalanceTransactionsQuery : IRequest<List<BalanceTransactionDTO>>
    {
        public GetBalanceTransactionsQuery(Guid balanceid)
        {
            this.BalanceId = balanceid;    
        }
        public Guid BalanceId { get; set; }
    }
}
