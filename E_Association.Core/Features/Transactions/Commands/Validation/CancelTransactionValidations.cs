using E_Association.Core.Application.Features.Transactions.Commands.Query;
using FluentValidation;

namespace E_Association.Core.Application.Features.Transactions.Commands.Model
{
    public class CancelTransactionValidations : AbstractValidator<DeleteTransactionCommand>
    {
        public CancelTransactionValidations()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
