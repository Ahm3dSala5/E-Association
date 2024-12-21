using MediatR;

namespace E_Association.Core.Features.Withdrawal.Command.Request
{
    public class StartWithdrawalCommand :IRequest<string>
    {
    
        public StartWithdrawalCommand(Guid _userId, decimal _amount)
        {
            this.userId = _userId;
            this.amount = _amount;
        }
        public Guid userId { set; get; }
        public decimal amount { set; get; }
    }
}
