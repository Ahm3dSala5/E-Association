using E_Association.Core.Features.Notification.Command.Request;
using FluentValidation;

public class SendNotificationToUserValidatuons : AbstractValidator<SendNotificationToUserCommand>
    {
        public SendNotificationToUserValidatuons()
        {
           RuleFor(x => x.Title).NotEmpty().MinimumLength(5);
           RuleFor(x => x.Message).NotEmpty().MinimumLength(10);
           RuleFor(x => x.UserId).NotEmpty();
        }
    }

