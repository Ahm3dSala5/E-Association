using E_Association.Core.Features.Payments.Command.Request;
using FluentValidation;

namespace E_Association.Core.Features.Payments.Command.Validation
{
    public class StartPaymentValidations : AbstractValidator<StartPaymentCommand>
    {
        public StartPaymentValidations()
        {
            RuleFor(x=>x.userId).NotEmpty();
            RuleFor(x=>x.associationId).NotEmpty();
            RuleFor(x=>x.amount).NotEmpty().NotEqual(0);
        }
    }
}
