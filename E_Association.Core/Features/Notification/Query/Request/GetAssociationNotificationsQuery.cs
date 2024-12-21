using MediatR;

namespace E_Association.Core.Features.Notification.Query.Handler
{
    public class GetAssociationNotificationsQuery : IRequest<List<NotificationModel>>
    {
        public GetAssociationNotificationsQuery(string _associationName)
        {
            this.AssociationName = _associationName;
        }
        public string AssociationName { set; get; }
    }
}
