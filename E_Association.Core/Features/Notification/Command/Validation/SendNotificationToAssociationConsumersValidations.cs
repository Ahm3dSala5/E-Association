using E_Association.Core.Features.Notification.Command.Request;
using FluentValidation;

public class SendNotificationToAssociationConsumersValidations : AbstractValidator<SendNotificationToAssociationConsumersCommand>
    {
        public SendNotificationToAssociationConsumersValidations()
        {
            RuleFor(x => x.Title).NotEmpty().MinimumLength(5);
            RuleFor(x => x.Message).NotEmpty().MinimumLength(10);
            RuleFor(x => x.associationName).NotEmpty().MinimumLength(5);
        }
    }

