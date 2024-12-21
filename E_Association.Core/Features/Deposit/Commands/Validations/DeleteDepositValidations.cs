using E_Association.Core.Features.Deposit.Commands.Request;
using FluentValidation;

namespace E_Association.Core.Features.Deposit.Commands.Validations
{
    public class DeleteDepositValidations : AbstractValidator<DeleteDepositCommand>
    {
        public DeleteDepositValidations()
        {
            RuleFor(x=>x.DepositeId).NotEmpty();
        }
    }
}
