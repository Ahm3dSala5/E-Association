using E_Association.Core.Features.Authorization.Query.Request;
using E_Association.Service.IAssociationServices.Userservice;
using MediatR;

namespace E_Association.Core.Features.Authorization.Query.Handler
{
    public class AuthorizationQueryHandler :
        IRequestHandler<GetAllRolesQuery, List<string>> ,
        IRequestHandler<GetUserRolQuery,string> 
    {
        private IAuthorizationService _service;
        public AuthorizationQueryHandler(IAuthorizationService service)
        {
            this._service = service;
        }
        public async Task<List<string>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetAllRoleAsync();
        }

        public async Task<string> Handle(GetUserRolQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetUserRoleAsync(request.UserName);
        }
    }
}
