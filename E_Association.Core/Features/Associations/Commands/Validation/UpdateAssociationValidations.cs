using E_Association.Core.Features.Associations.Commands.Request;
using FluentValidation;

namespace E_Association.Core.Features.Associations.Commands.Validation
{
    public class UpdateAssociationValidations :AbstractValidator<UpdateAssociationCommand>
    {
        public UpdateAssociationValidations()
        {
            RuleFor(x => x.Name).MinimumLength(5).NotEmpty();
            RuleFor(x => x.Capacity).NotEmpty();
            RuleFor(x => x.state).NotEmpty();
            RuleFor(x => x.StartAt).NotEmpty().NotEqual(x=>x.EndAt);
            RuleFor(x=>x.EndAt).NotEmpty();
        }
    }

}
