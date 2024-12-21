using E_Association.Core.Features.Deposit.Commands.Request;
using E_Association.Core.Features.Withdrawal.Command.Request;
using FluentValidation;

namespace E_Association.Core.Features.Withdrawal.Command.Validation
{
    public class StartWithdrawalsValidations : AbstractValidator<StartWithdrawalCommand>
    {
        public StartWithdrawalsValidations()
        {
            RuleFor(x=>x.userId).NotEmpty();
            RuleFor(x => x.amount).NotEmpty().NotEqual(0);
        }
    }
}
