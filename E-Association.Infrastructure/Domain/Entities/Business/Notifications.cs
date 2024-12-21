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
        public ApplicationUser ?User { set; get; }

        public ICollection<Association> Subscriptions { set; get; } = new List<Association>();
        public ICollection<SubscriptionNotifications> SubscriptionNotifications { set; get; } = new List<SubscriptionNotifications>();

    }
}
