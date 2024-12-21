using E_Association.Core.Features.Balances.Query.Models;
using MediatR;

namespace E_Association.Core.Features.Balances.Query.Request
{
    public class GetUserBalanceQuery :IRequest<BalanceDTO>
    {
        public GetUserBalanceQuery(Guid _userId)
        {
            this.userId = _userId;
        }
        public Guid userId { set; get; }
              
    }
}
