using E_Association.Core.Features.Notification.Command.Request;
using FluentValidation;

namespace E_Association.Core.Features.Notification.Command.Validation
{
    public class CreateNotificationValidations : AbstractValidator<CreateNotificationCommand>
    {
        public CreateNotificationValidations()
        {
            RuleFor(x => x.NotificationContent).NotEmpty().MinimumLength(10);
        }
    }
}
      

