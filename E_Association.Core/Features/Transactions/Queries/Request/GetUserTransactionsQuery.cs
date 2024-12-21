using E_Association.Core.Application.Features.Transactions.Commands.Model;
using E_Association.Core.Features.Transactions.Queries.Model;
using MediatR;

namespace E_Association.Core.Features.Transactions.Queries.Request
{
    public class GetUserTransactionsQuery : IRequest<List<TransactionModel>>
    {
        public GetUserTransactionsQuery(Guid userId)
        {
            this.Id = userId;
        }
        public Guid Id { set; get; }
    }
}
