namespace Domain.Entities.Business
{
    public class AssociationNotifications
    {
        public Guid SubScriptionId { set; get; }
        public Association SubScription { set; get; }
        public Guid NotificationsId { set; get; }
        public Notifications Notification { set; get; }
    }
}
