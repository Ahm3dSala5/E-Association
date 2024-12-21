using Domain.DTOs.Subscriptions;
using E_Association.Core.Domain.Enums;
using MediatR;

namespace E_Association.Core.Features.Associations.Commands.Request
{
    public class CreateAssociationCommand :IRequest<string>
    {
        public CreateAssociationCommand(AssociationDTO associations)
        {
            this.Name = associations.Name;
            this.StartAt = associations.StatAt;
            this.EndAt = associations.EndAt;
            this.Capacity = associations.Capacity;
            this.state = associations.state;
            this.Amount = associations.Amount;
        }
        public string Name { set; get; }
        public decimal Amount { set; get; }
        public int Capacity { set; get; }
        public AssociationStatus state { set; get; }
        public DateTime StartAt { set; get; }
        public DateTime EndAt { set; get; }
    }
}