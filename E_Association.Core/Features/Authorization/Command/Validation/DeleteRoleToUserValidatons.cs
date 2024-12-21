using E_Association.Core.Features.Authorization.Command.Request;
using FluentValidation;

namespace E_Association.Core.Features.Authorization.Command.Validation
{
    public class DeleteRoleToUserValidatons : AbstractValidator<DeleteRoleCommand>
    {
        public DeleteRoleToUserValidatons()
        {
            RuleFor(x => x.Role).MaximumLength(4).NotEmpty();
        }
    }
}
