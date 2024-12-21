using MediatR;

namespace E_Association.Core.Features.Association.Query
{
    public class GetAssociationConsumerByNameQuery : IRequest<List<string>>
    {
        public GetAssociationConsumerByNameQuery(string associatioName)
        {
            this.AssociationName = associatioName;
        }
        public string AssociationName { set; get; }
    }
}
