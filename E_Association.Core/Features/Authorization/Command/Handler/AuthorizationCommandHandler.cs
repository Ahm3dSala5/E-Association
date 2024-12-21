using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Association.Core.Features.Authorization.Command.Request;
using E_Association.Service.IAssociationServices.Userservice;
using MediatR;
using Microsoft.AspNetCore.Http.Features.Authentication;

namespace E_Association.Core.Features.Authorization.Command.Handler
{
    public class AuthorizationCommandHandler :
        IRequestHandler<CreateRoleCommand, string> ,
        IRequestHandler<DeleteRoleCommand, string> ,
        IRequestHandler<UpdateRoleCommand, string> ,
        IRequestHandler<UpdateUserRoleCommand, string> ,
        IRequestHandler<AssignRoleToUserCommand, string> ,
        IRequestHandler<DeleteUserFromRoleCommand, string> 
    {
        private IAuthorizationService _service;
        public AuthorizationCommandHandler(IAuthorizationService service)
        {
            this._service = service;
        }
        public async Task<string> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            return await _service.CreateRoleAsync(request.Role);
        }

        public async Task<string> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            return await _service.DeletRoleAsync(request.Role);
        }

        public async Task<string> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            return await _service.UpdateRoleAsync(request.OldRole,request.NewRole);
        }

        public async Task<string> Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
        {
            return await _service.UpdateUserRoleAsync(request.userName,request.OldRole,request.NewRole);
        }

        public async Task<string> Handle(AssignRoleToUserCommand request, CancellationToken cancellationToken)
        {
            return await _service.AssignUserToRoleAsync(request.userName,request.Role);
        }

        public async Task<string> Handle(DeleteUserFromRoleCommand request, CancellationToken cancellationToken)
        {
            return await _service.DeleteUserFromRoleAsync(request.userName,request.Role);
        }
    }
}
