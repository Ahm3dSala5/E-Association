using E_Association.Core.Features.Notification.Command.Request;
using FluentValidation;

namespace E_Association.Core.Features.Notification.Command.Validation
{
    public class DeleteNotificationValidations : AbstractValidator<DeleteNotificationCommand>
    {
        public DeleteNotificationValidations()
        {
            RuleFor(x => x.notificationId).NotEmpty();
        }
    }
    }

