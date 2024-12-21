using Domain.Entities.Business;
using E_Association.Core.Features.Withdrawal.Query.Models;
using MediatR;

namespace E_Association.Core.Features.Withdrawal.Query.Request
{
    public class GetUserWithdrawalsQuery :IRequest<List<WithdrawalModel>>
    {
        public GetUserWithdrawalsQuery(Guid userId)
        {
            this.userId = userId;
        }
        public Guid userId { set; get; }
    }
}
