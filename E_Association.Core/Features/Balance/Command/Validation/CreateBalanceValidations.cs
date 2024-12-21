using E_Association.Core.Features.Balances.Command.Request;
using FluentValidation;

namespace E_Association.Core.Features.Balance.Command.Validation
{
    public class CreateBalanceValidations : AbstractValidator<CreateBalanceCommand>
    {
        public CreateBalanceValidations()
        {
            RuleFor(x=>x.Amount).NotEmpty().Equal(0);
            RuleFor(x=>x.CreatedAt).NotEmpty();
            RuleFor(x=>x.UserId).NotEmpty();
        }
    }
}
