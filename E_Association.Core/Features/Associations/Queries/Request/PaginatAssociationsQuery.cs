using Domain.DTOs.Subscriptions;
using Domain.Entities.Business;
using MediatR;

namespace E_Association.Core.Features.Association.Query
{
    public class PaginatAssociationsQuery : IRequest<List<AssociationDTO>>
    {
        public PaginatAssociationsQuery(int _pageSize, int _PageNmber)
        {
            this.pageSize = _pageSize;
            this.pageNumber = _PageNmber;
        }
        public int pageSize { set; get; }
        public int pageNumber { set; get; }
    }
}
