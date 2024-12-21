using E_Association.Core.Features.Payments.Command.Request;
using FluentValidation;

namespace E_Association.Core.Features.Payments.Command.Validation
{
    public class UpdatePaymentValidations :AbstractValidator<UpdatePaymentCommand>
    {
        public UpdatePaymentValidations()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.AssociationId).NotEmpty();
            RuleFor(x => x.PaymentId).NotEmpty();
            RuleFor(x => x.Amount).NotEmpty().NotEqual(0);
        }
    }
}
