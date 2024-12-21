using MediatR;

namespace E_Association.Core.Features.Notification.Command.Request
{
    public class SendNotificationToAllUserCommand :IRequest<string>
    {
        public SendNotificationToAllUserCommand(string title, string message)
        {
            this.Title = title;
            this.Message = message;
        }
        public string Title { set; get; }
        public string Message { set; get; } 
    }
}
