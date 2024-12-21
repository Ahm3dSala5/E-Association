using E_Association.Core.Domain.Enums;
using E_Association.Infrastructure.Domain.DTOs.Transactions;
using MediatR;
using Presitences.Configurations.Securities.Respones;

namespace E_Association.Core.Application.Features.Transactions.Commands.Query
{
    public class UpdateTransactionCommand :IRequest<string>
    {
        public UpdateTransactionCommand(TransactionDTO transaction)
        {
            this.UserId = transaction.UserId;
            this.BalanecId = transaction.BalanecId;
            this.BalancePassword = transaction.BalancePassword;
            this.state = transaction.state;
            this.Amount = transaction.Amount;
        }
        public Guid UserId { get; set; }
        public Guid BalanecId { set; get; }
        public string BalancePassword { set; get; }
        public decimal Amount { set; get; }
        public TransactionState state { set; get; }
    }
}