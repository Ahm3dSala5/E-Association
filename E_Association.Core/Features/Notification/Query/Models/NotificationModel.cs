using MediatR;

namespace E_Association.Core.Features.Notification.Query.Handler
{
    public  class NotificationModel
    {
        public Guid Id { set; get; }
        public string Message { set; get; }
        public DateTime CreatedAt { set; get; }
        public Guid? UserId { set; get; }
    }
}
