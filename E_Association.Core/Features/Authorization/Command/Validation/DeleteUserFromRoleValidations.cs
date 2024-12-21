using E_Association.Core.Features.Authorization.Command.Request;
using FluentValidation;

namespace E_Association.Core.Features.Authorization.Command.Validation
{
    public class DeleteUserFromRoleValidations : AbstractValidator<DeleteUserFromRoleCommand>
    {
        public DeleteUserFromRoleValidations()
        {
            RuleFor(x => x.userName).MaximumLength(8).NotEmpty();
            RuleFor(x => x.Role).MaximumLength(4).NotEmpty();
        }
    }
}
