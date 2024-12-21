using E_Association.Core.Features.Deposit.Commands.Handler;
using E_Association.Infrastructure.Domain.DTOs.Deposit;
using MediatR;

namespace E_Association.Core.Features.Deposit.Queries.request
{
    public class GetDepositDetailsQuery : IRequest<DepositModel>
    {
        public GetDepositDetailsQuery(Guid depositId)
        {
            this.DepositId = depositId;
        }
        public Guid DepositId { set; get; }
    }
}
