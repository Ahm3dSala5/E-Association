using Application.Requests.User.Commands.Queries;
using FluentValidation;

namespace E_Association.Core.Features.User.Commands.Validation
{
    public class ForgetUserPasswordValidations : AbstractValidator<ForgetUserPasswordCommand>
    {
        public ForgetUserPasswordValidations()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.NewPassword).NotEmpty().MinimumLength(8);
            RuleFor(x => x.verificationCode).NotEmpty().Length(6);
        }
    }


}
