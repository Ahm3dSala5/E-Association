using MediatR;

namespace E_Association.Core.Features.Notification.Query.Handler
{
    public class GetUserNotificationQuery : IRequest<List<NotificationModel>>
    {
        public GetUserNotificationQuery(string _userid)
        {
            this.userid = _userid;
        }
        public string userid { set; get; }
    }
}
