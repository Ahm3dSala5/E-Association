using Application.Requests.User.Commands.Queries;
using FluentValidation;

namespace E_Association.Core.Features.User.Commands.Validation
{
    public class RegisterUserValidations : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserValidations()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.UserName).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().EmailAddress().Equal(x=>x.ConfirmPassword);
            RuleFor(x => x.ConfirmPassword).NotEmpty().EmailAddress();
            RuleFor(x => x.Address).NotEmpty().EmailAddress();
        }
    }


}
