using E_Association.Core.Application.Features.Transactions.Commands.Query;
using FluentValidation;

namespace E_Association.Core.Application.Features.Transactions.Commands.Model
{
    public class UpdateTransactionValidations : AbstractValidator<UpdateTransactionCommand>
    {
        public UpdateTransactionValidations()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.BalancePassword).NotEmpty().MinimumLength(8);
            RuleFor(x => x.BalanecId).NotEmpty();
            RuleFor(x => x.state).NotEmpty();
            RuleFor(x => x.Amount).NotEmpty().NotEqual(0);
        }
    }
}
