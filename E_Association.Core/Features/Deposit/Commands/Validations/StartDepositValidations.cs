using E_Association.Core.Features.Deposit.Commands.Request;
using FluentValidation;

namespace E_Association.Core.Features.Deposit.Commands.Validations
{
    public class StartDepositValidations : AbstractValidator<StartDepositCommand>
    {
        public StartDepositValidations()
        {
            RuleFor(x => x.userId).NotEmpty();
            RuleFor(x => x.Amount).NotEmpty().NotEqual(0);
        }
    }
}
