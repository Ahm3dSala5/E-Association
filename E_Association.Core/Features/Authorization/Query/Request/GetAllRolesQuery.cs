using MediatR;

namespace E_Association.Core.Features.Authorization.Query.Request
{
    public class GetAllRolesQuery :IRequest<List<string>>
    {
        public GetAllRolesQuery()
        {

        }
    }
}
