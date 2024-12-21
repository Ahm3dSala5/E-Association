using MediatR;

namespace E_Association.Core.Features.Association.Query
{
    public class GetAssociationCollectorForCurrentMonthQuery : IRequest<string>
    {
        public GetAssociationCollectorForCurrentMonthQuery(string associtionName)
        {
            this.AssociatioName = associtionName;
        }
        public string AssociatioName { set; get; }
    }
}
