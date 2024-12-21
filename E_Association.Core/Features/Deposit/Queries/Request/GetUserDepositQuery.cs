using E_Association.Core.Features.Deposit.Commands.Handler;
using MediatR;

namespace E_Association.Core.Features.Deposit.Queries.request
{
    public class GetUserDepositQuery :IRequest<List<DepositModel>>
    {
        public GetUserDepositQuery(string username)
        {
            this.UserName = username;
        }
        public string UserName { set; get; }
    }
}
