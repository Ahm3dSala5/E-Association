using Domain.Entities.Securities;

namespace Domain.Entities.Business
{
    public class ConsumerAssociations
    {
        public Guid UserId { set; get; }
        public Consumer User { set; get; }
        public Guid SubscriptionId { set; get; }
        public Association Association { set; get; }
    }
}
