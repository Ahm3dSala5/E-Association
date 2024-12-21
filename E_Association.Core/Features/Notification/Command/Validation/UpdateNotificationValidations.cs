using E_Association.Core.Features.Notification.Command.Request;
using FluentValidation;

namespace E_Association.Core.Features.Notification.Command.Validation
{
    public class UpdateNotificationValidations : AbstractValidator<UpdateNotificationCommand>
    {
        public UpdateNotificationValidations()
        {
            RuleFor(x => x.NotificationId).NotEmpty();
            RuleFor(x => x.newMessage).NotEmpty().MinimumLength(10);
        }
    }
    }

