using E_Association.Core.Features.Notification.Command.Request;
using FluentValidation;

namespace E_Association.Core.Features.Notification.Command.Validation
{
    public class SendNotificationToAllUserValidations : AbstractValidator<SendNotificationToAllUserCommand>
    {
        public SendNotificationToAllUserValidations()
        {
            RuleFor(x => x.Title).NotEmpty().MinimumLength(5);
            RuleFor(x => x.Message).NotEmpty().MinimumLength(10);
        }
    }
    }

