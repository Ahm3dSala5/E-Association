using MediatR;

namespace E_Association.Core.Features.Notification.Command.Request
{
    public class UpdateNotificationCommand :IRequest<string>
    {
        public UpdateNotificationCommand(Guid _notificationId, string _newMessage)
        {
            this.newMessage = _newMessage;
            this.NotificationId = _notificationId;
        }
        public Guid NotificationId { set; get; }
        public string newMessage { set; get; }
    }
}
