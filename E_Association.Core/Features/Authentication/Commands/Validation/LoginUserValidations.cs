using Application.Requests.User.Commands.Queries;
using FluentValidation;

namespace E_Association.Core.Features.User.Commands.Validation
{
    public class LoginUserValidations : AbstractValidator<LoginUserCommand>
    {
        public LoginUserValidations()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
        }
    }


}
