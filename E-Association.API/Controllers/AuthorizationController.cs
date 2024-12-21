using E_Association.Core.Features.Authorization.Command.Request;
using E_Association.Core.Features.Authorization.Query.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Association.API.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class AuthorizationController :ControllerBase
    {
        private IMediator _mediator;
        public AuthorizationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateRole")]
        public async Task<IActionResult> Create(string role)
        {
            return Ok(await _mediator.Send(new CreateRoleCommand(role)));
        }

        [HttpPost("AssignRoleToUser")]
        public async Task<IActionResult> AssignRoleToUser(string userName,string role)
        {
            return Ok(await _mediator.Send(new AssignRoleToUserCommand(userName,role)));
        }

        [HttpGet("GetUserRole/{username}")]
        public async Task<IActionResult> GetUserRole(string username)
        {
            return Ok(await _mediator.Send(new GetUserRolQuery(username)));
        }

        [HttpGet("GetAllRole")]
        public async Task<IActionResult> GetAllRole()
        {
            return Ok(await _mediator.Send(new GetAllRolesQuery()));
        }

        [HttpPut("UpdateRole")]
        public async Task<IActionResult> UpdateRole(string oldRole , string newRole)
        {
            return Ok(await _mediator.Send(new UpdateRoleCommand(oldRole,newRole)));
        }

        [HttpPut("UpdateUserRoles/{userName}")]
        public async Task<IActionResult> UpdateUserRole(string userName, string oldRole, string newRole)
        {
            return Ok(await _mediator.Send(new UpdateUserRoleCommand(userName,oldRole, newRole)));
        }

        [HttpDelete("DeleteUserFormRole/{userName}")]
        public async Task<IActionResult> DeleteFromRole(string username, string role)
        {
            return Ok(await _mediator.Send(new DeleteUserFromRoleCommand(username , role)));
        }

        [HttpDelete("DeletRole/{name}")]
        public async Task<IActionResult> DeleteRole(string role)
        {
            return Ok(await _mediator.Send(new DeleteRoleCommand(role)));
        }

    }
}
