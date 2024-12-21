using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Association.Core.Features.Associations.Commands.Request;
using FluentValidation;

namespace E_Association.Core.Features.Associations.Commands.Validation
{
    public class ApplyToAssociationValidations : AbstractValidator<ApplyToAssociationCommand>
    {
        public ApplyToAssociationValidations()
        {
            RuleFor(x=>x.applicantName).NotEmpty().MaximumLength(5);
            RuleFor(x=>x.associationName).NotEmpty().MaximumLength(5);
            RuleFor(x=>x.getCashInMonth).NotEmpty();
        }
    }
}
