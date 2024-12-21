using E_Association.Core.Features.Withdrawal.Command.Request;
using FluentValidation;

namespace E_Association.Core.Features.Withdrawal.Command.Validation
{
    public class CanceWithdrawalsValidations : AbstractValidator<CalncelationWithdrwalCommand>
    {
        public CanceWithdrawalsValidations()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
