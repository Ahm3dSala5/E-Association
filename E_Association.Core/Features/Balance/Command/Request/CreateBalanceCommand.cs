using Domain.Entities.Business;
using E_Association.Core.Features.Balances.Query.Models;
using MediatR;
namespace E_Association.Core.Features.Balances.Command.Request
{
    public class CreateBalanceCommand :IRequest<string>
    {
        public CreateBalanceCommand(BalanceDTO balance)
        {
            this.Amount = balance.Amount;
            this.CreatedAt = balance.CreatedAt;
            this.UserId = balance.UserId;
        }
        public decimal Amount { set; get; }
        public DateTime CreatedAt { set; get; }
        public Guid UserId { get; set; }
    }
}
