using Application.Requests.User.Commands.Queries;
using FluentValidation;

namespace E_Association.Core.Features.User.Commands.Validation
{
    public class ConfirmUserValidations : AbstractValidator<ConfirmUserCommand>
    {
        public ConfirmUserValidations()
        {
            RuleFor(x => x.UserName).MinimumLength(8).NotEmpty();
            RuleFor(x => x.ConfirmationCode).Length(6).NotEmpty();
        }
    }


}
