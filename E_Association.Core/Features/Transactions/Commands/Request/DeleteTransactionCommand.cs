using MediatR;
using Presitences.Configurations.Securities.Respones;

namespace E_Association.Core.Application.Features.Transactions.Commands.Query
{
    public class DeleteTransactionCommand : IRequest<string>
    {
        public DeleteTransactionCommand(Guid transactionId)
        {
            this.Id = transactionId;
        }
        public Guid Id { set; get; }
    }
}