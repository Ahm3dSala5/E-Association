using MediatR;

namespace E_Association.Core.Features.Authorization.Command.Request
{
    public class UpdateRoleCommand :IRequest<string>
    {
        public UpdateRoleCommand(string oldRole, string newRole)
        {
            this.NewRole = newRole;
            this.OldRole = oldRole;
        }

        public string NewRole { set; get; }
        public string OldRole { set; get; }
    }
}
