using Domain.Entities.Business;
using E_Association.Core.Features.Notification.Query.Handler;
using E_Association.Core.Features.Transactions.Queries.Request;

namespace E_Association.Core.Mapping.Notification
{
    public partial class NotificationProfile
    {
        public void AddGetUserNotificationsMapping()
        {
            CreateMap<Notifications, GetUserNotificationQuery>();
        }

        public void AddGetAssociationNotificationsMapping()
        {
            CreateMap<Notifications, GetAssociationNotificationsQuery>();
        }
    }
}
