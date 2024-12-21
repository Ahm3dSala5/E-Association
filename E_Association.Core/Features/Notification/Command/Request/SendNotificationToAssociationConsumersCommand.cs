using MediatR;

namespace E_Association.Core.Features.Notification.Command.Request
{
    public class SendNotificationToAssociationConsumersCommand :IRequest<string>
    {
        public SendNotificationToAssociationConsumersCommand(string title, string message, string subscriptionCode)
        {
            this.associationName = subscriptionCode;
            this.Title = title;
            this.Message = message;
        }
        public string Title { set; get; }
        public string Message { set; get; }
        public string associationName { set; get; }
    }
}
