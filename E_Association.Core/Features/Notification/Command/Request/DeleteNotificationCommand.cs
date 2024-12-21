using MediatR;

namespace E_Association.Core.Features.Notification.Command.Request
{
    public class DeleteNotificationCommand :IRequest<string>
    {
        public DeleteNotificationCommand(Guid _notificationId)
        {
            this.notificationId = _notificationId;
        }
        public Guid notificationId { set; get; }
    }
}
