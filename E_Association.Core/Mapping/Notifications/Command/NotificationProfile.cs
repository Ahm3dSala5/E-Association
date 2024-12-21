using AutoMapper;
using Domain.Entities.Business;
using E_Association.Core.Application.Features.Transactions.Commands.Query;
using E_Association.Core.Features.Notification.Command.Request;

namespace E_Association.Core.Mapping.Notification
{
    public partial class NotificationProfile
    {
        public void AddSendNotificationToUserMapping()
        {
            CreateMap<Notifications, CreateNotificationCommand>();
        }

        public void AddSendNotificationToAssociationConsumersMapping()
        {
            CreateMap<Notifications,DeleteNotificationCommand>();
        }

        public void AddSendNotificationToAllUserCommandMapping()
        {
            CreateMap<Notifications, UpdateNotificationCommand>();
        }

        public void AddCreateNotificationMapping()
        {
            CreateMap<Notifications, SendNotificationToUserCommand>();
        }

        public void AddDeleteNotificationMapping()
        {
            CreateMap<Notifications, SendNotificationToAssociationConsumersCommand>();
        }

        public void AddUpdateNotificationsMapping()
        {
            CreateMap<Notifications, SendNotificationToAllUserCommand>();
        }
    }
}
