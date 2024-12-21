using Domain.DTOs.Subscriptions;
using Domain.Entities.Business;
using MediatR;

namespace E_Association.Core.Features.Association.Query
{
    public class GetAssociationByIdQuery : IRequest<AssociationDTO>
    {
        public GetAssociationByIdQuery(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
    }
}
