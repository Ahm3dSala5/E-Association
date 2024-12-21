using E_Association.Core.Features.Withdrawal.Query.Models;
using MediatR;

namespace E_Association.Core.Features.Withdrawal.Query.Request
{
    public class GetWithdrawalDetailsQuery :IRequest<WithdrawalModel>
    {
        public GetWithdrawalDetailsQuery(Guid withdrawalId)
        {
            this.Id = withdrawalId;
        }
        public Guid Id { set; get; }
    }
}
