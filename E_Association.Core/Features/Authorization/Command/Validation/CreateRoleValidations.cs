using E_Association.Core.Features.Authorization.Command.Request;
using FluentValidation;

namespace E_Association.Core.Features.Authorization.Command.Validation
{
    public class CreateRoleValidations : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleValidations()
        {
            RuleFor(x => x.Role).MaximumLength(4).NotEmpty();
        }
    }
}
