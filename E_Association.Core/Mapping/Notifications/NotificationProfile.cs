using AutoMapper;

namespace E_Association.Core.Mapping.Notification
{
    public partial class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            
            AddGetUserNotificationsMapping();
            AddGetAssociationNotificationsMapping();
        }
    }
}
