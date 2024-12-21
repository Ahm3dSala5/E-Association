using E_Association.Core.Domain.Enums;

namespace Domain.DTOs.Subscriptions
{
    public class AssociationDTO
    {
        public string Name { set; get; }
        public decimal Amount { set; get; }
        public int Capacity { set; get; }
        public AssociationStatus state { set; get; }
        public DateTime StatAt { set; get; }
        public DateTime EndAt { set; get; }
    }
}
