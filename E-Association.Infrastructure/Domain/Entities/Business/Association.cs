using Domain.Entities.Securities;
using E_Association.Core.Domain.Enums;

namespace Domain.Entities.Business
{
    public class Association
    {
        public Guid Id { set; get; }
        public string Name { set; get; }
        public decimal MonthlyAmount { set; get; }
        public int Capacity { set; get; }
        public int Applicants { set; get; }
        public decimal TotalBalance { set; get; }
        public Guid Collector { set; get; }
        public AssociationStatus Status { set; get; }
        public DateTime StartAt { set; get; }
        public DateTime EndAt { set; get; }
        
        public ICollection<Consumer> Users { set; get; } = new List<Consumer>();
        public ICollection<ConsumerAssociations> UserSubscriptions { set; get; } = new List<ConsumerAssociations>();
        public ICollection<Notifications> Notifications { set; get; } = new List<Notifications>();
        public ICollection<AssociationNotifications> SubscriptionNotifications { set; get; } = new List<AssociationNotifications>();
        public ICollection<Payment> Payments { set; get; } = new List<Payment>();
    }
   
}
