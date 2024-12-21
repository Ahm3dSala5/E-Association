using MediatR;

namespace E_Association.Core.Features.Deposit.Commands.Request
{
    public class StartDepositCommand :IRequest<string>
    {
        public StartDepositCommand(Guid userid , decimal amount)
        {
            this.userId = userid;
            this.Amount = amount;
        }
        public Guid userId { set; get; }
        public decimal Amount { set; get; }
    }
}
