using E_Association.Core.Features.Withdrawal.Query.Models;
using MediatR;

namespace E_Association.Core.Features.Withdrawal.Query.Request
{
    public class GetAllWithdrawalsQuery :IRequest<List<WithdrawalModel>>
    {

    }
}
