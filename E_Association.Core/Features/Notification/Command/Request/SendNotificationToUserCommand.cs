using MediatR;

namespace E_Association.Core.Features.Notification.Command.Request
{
    public class SendNotificationToUserCommand :IRequest<string>
    {
        public SendNotificationToUserCommand(string title, string message, Guid userId)
        {
            this.UserId = userId;
            this.Title = title;
            this.Message = message;
        }
        public string Title { set; get; }
        public string Message { set; get; }
        public Guid UserId { set; get; }
    }
}
