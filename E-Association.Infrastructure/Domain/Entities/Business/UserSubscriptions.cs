using Domain.Entities.Securities;

namespace Domain.Entities.Business
{
    public class UserSubscriptions
    {
        public Guid UserId { set; get; }
        public ApplicationUser User { set; get; }
        public Guid SubscriptionId { set; get; }
        public Association SubScription { set; get; }

    }
}
