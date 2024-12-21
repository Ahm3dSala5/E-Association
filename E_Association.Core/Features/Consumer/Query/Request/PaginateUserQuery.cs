using E_Association.Core.Features.Consumer.Query.Models;
using MediatR;

namespace E_Association.Core.Features.Consumer.Query.Request
{
    public class PaginateUserQuery : IRequest<List<UserModel>>
    {
        public PaginateUserQuery(int _userPerPage, int _pageNumber)
        {
            pageNumber = _pageNumber;
            UserPerPage = _userPerPage;
        }
        public int UserPerPage { get; set; }
        public int pageNumber { set; get; }
    }
}
