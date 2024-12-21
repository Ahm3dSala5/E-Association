using Application.Requests.User.Commands.Queries;
using FluentValidation;

namespace E_Association.Core.Features.User.Commands.Validation
{
    public class DeleteUserValidations : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserValidations()
        {
            RuleFor(x => x.UserName).NotEmpty().MinimumLength(8);
        }
    }


}
