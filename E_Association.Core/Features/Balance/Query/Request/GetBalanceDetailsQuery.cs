using E_Association.Core.Features.Balances.Query.Models;
using MediatR;

namespace E_Association.Core.Features.Balances.Query.Request
{
    public class GetBalanceDetailsQuery : IRequest<BalanceDetailsDTO>
    {
        public GetBalanceDetailsQuery(Guid balanceId)
        {
            this.BalanceId = balanceId;
        }
        public Guid BalanceId { get; set; }
    }
}
