using E_Association.Core.Features.Balances.Command.Request;
using FluentValidation;

namespace E_Association.Core.Features.Balance.Command.Validation
{
    public class DeleteBalanceValidations : AbstractValidator<DeleteBalanceCommand>
    {
        public DeleteBalanceValidations()
        {
            RuleFor(x=>x.id).NotEmpty().NotNull();
        }
    }
}
