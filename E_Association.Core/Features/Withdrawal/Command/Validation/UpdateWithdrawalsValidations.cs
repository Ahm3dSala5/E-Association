using E_Association.Core.Features.Withdrawal.Command.Request;
using FluentValidation;

namespace E_Association.Core.Features.Withdrawal.Command.Validation
{
    public class UpdateWithdrawalsValidations : AbstractValidator<UpdateWithdrawalCommand>
    {
        public UpdateWithdrawalsValidations()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.Amount).NotEmpty().NotEqual(0);
            RuleFor(x => x.WithdrawalAt).NotEmpty();
            RuleFor(x => x.Status).NotEmpty();
        }
    }
}
