using E_Association.Core.Features.Deposit.Commands.Handler;
using MediatR;

namespace E_Association.Core.Features.Deposit.Queries.request
{
    public class GetAllDepositsQuery :IRequest<List<DepositModel>>
    {

    }
}
