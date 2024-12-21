using E_Association.Core.Features.Payments.Command.Request;
using FluentValidation;

namespace E_Association.Core.Features.Payments.Command.Validation
{
    public class CancellationPaymentValidations : AbstractValidator<CancellationPaymentCommand>
    {
        public CancellationPaymentValidations()
        {
            RuleFor(x => x.PaymentId).NotEmpty();
        }
    }
}
