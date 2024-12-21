using E_Association.Core.Features.Authorization.Command.Request;
using FluentValidation;

namespace E_Association.Core.Features.Authorization.Command.Validation
{
    public class UpdateRoleValidations : AbstractValidator<UpdateRoleCommand>
    {
        public UpdateRoleValidations()
        {
            RuleFor(x => x.OldRole).MaximumLength(8).NotEmpty();
            RuleFor(x => x.NewRole).MaximumLength(4).NotEmpty();
        }
    }
}
