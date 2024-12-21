using E_Association.Core.Features.Deposit.Commands.Request;
using FluentValidation;
namespace E_Association.Core.Features.Deposit.Commands.Validations
{
    public class UpdateDepositValidations : AbstractValidator<UpdateDepositCommand>
    {
        public UpdateDepositValidations()
        {
            RuleFor(x => x.Userid).NotEmpty();
            RuleFor(x => x.Depositid).NotEmpty();
            RuleFor(x => x.Newamoutt).NotEmpty().NotEqual(0);
        }
    }
}
