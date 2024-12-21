using E_Association.Core.Features.Associations.Commands.Request;
using FluentValidation;

namespace E_Association.Core.Features.Associations.Commands.Validation
{
    public class DeleteAssociationValidations :AbstractValidator<DeleteAssociationCommand>
    {
        public DeleteAssociationValidations()
        {
            RuleFor(x => x.Name).MinimumLength(5).NotEmpty();
        }
    }

}
