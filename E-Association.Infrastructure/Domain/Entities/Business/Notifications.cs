using System.Text;
using Domain.Entities.Securities;

namespace Domain.Entities.Business
{
    public class Notifications
    {
        public Guid Id { set; get; }
        public string Message { set; get; }
        public DateTime CreatedAt { set; get; }
        public Guid? UserId { set; get; }
        public Consumer ?User { set; get; }
        public ICollection<Association> Subscriptions { set; get; } = new List<Association>();
        public ICollection<AssociationNotifications> SubscriptionNotifications { set; get; } = new List<AssociationNotifications>();
    }
}
