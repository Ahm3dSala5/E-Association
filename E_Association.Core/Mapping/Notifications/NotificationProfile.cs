using AutoMapper;

namespace E_Association.Core.Mapping.Notification
{
    public partial class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            AddCreateNotificationMapping();
            AddDeleteNotificationMapping();
            AddUpdateNotificationsMapping();
            AddGetUserNotificationsMapping();
            AddSendNotificationToUserMapping();
            AddGetAssociationNotificationsMapping();
            AddSendNotificationToAllUserCommandMapping();
            AddSendNotificationToAssociationConsumersMapping();
        }
    }
}
