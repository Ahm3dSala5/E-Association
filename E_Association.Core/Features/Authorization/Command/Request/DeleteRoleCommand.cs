using MediatR;

namespace E_Association.Core.Features.Authorization.Command.Request
{
    public class DeleteRoleCommand :IRequest<string>
    {
        public DeleteRoleCommand(string role)
        {
            this.Role = role;
        }
        public string Role { set; get; }
    }

}
