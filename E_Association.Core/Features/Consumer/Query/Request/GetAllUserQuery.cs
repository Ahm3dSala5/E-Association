using E_Association.Core.Features.Consumer.Query.Models;
using MediatR;

namespace E_Association.Core.Features.Consumer.Query.Request
{
    public class GetAllUserQuery : IRequest<List<UserModel>>
    {

    }
}
