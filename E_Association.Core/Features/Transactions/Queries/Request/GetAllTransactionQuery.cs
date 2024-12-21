using E_Association.Core.Application.Features.Transactions.Commands.Model;
using E_Association.Core.Features.Transactions.Queries.Model;
using MediatR;

namespace E_Association.Core.Features.Transactions.Queries.Request
{

    public class GetAllTransactionQuery : IRequest<List<TransactionModel>>
    {

    }
}
