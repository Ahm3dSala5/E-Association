using MediatR;

namespace E_Association.Core.Features.Notification.Command.Request
{
    public class CreateNotificationCommand :IRequest<string>
    {
        public CreateNotificationCommand(string content)
        {
            this.NotificationContent = content;
        }
        public string NotificationContent { set; get; }
    }
}
