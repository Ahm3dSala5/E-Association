using E_Association.Core.Features.Consumer.Query.Models;
using MediatR;

namespace E_Association.Core.Features.Consumer.Query.Request
{
    public class GetUserByUserNameQuery : IRequest<UserModel>
    {
        public GetUserByUserNameQuery(string _username)
        {
            userName = _username;
        }
        public string userName { set; get; }
    }
}
