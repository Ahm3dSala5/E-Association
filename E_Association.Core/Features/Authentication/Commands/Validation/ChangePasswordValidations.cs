using System.Diagnostics;
using Application.Requests.User.Commands.Queries;
using FluentValidation;

namespace E_Association.Core.Features.User.Commands.Validation
{
    public class ChangePasswordValidations : AbstractValidator<ChangeUserPasswordCommand>
    {
        public ChangePasswordValidations()
        {
            RuleFor(x=>x._Email).NotEmpty().EmailAddress();
            RuleFor(x => x._oldPassword).NotEmpty().MinimumLength(8);
            RuleFor(x => x._newPassword).NotEmpty().MinimumLength(8).Equal(x=>x._confirmNewPassword);
            RuleFor(x=>x._confirmNewPassword).NotEmpty().MinimumLength(8);
        }
    }
}
