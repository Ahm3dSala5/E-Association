using Application.Requests.User.Commands.Queries;
using FluentValidation;

namespace E_Association.Core.Features.User.Commands.Validation
{
    public class GenerateVerificationCodeValidations : AbstractValidator<GenerateVerificationCodeUserCommand>
    {
        public GenerateVerificationCodeValidations()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
        }
    }


}
