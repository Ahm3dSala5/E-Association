using E_Association.Core.Features.Authorization.Command.Request;
using FluentValidation;

namespace E_Association.Core.Features.Authorization.Command.Validation
{
    public class UpdateUserRoleValidations : AbstractValidator<UpdateUserRoleCommand>
    {
        public UpdateUserRoleValidations()
        {
            RuleFor(x => x.OldRole).MaximumLength(4).NotEmpty();
            RuleFor(x => x.NewRole).MaximumLength(4).NotEmpty();
            RuleFor(x => x.userName).MaximumLength(8).NotEmpty();
        }
    }
}
