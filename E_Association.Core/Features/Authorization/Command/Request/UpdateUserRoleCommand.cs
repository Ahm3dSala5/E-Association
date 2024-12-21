using MediatR;

namespace E_Association.Core.Features.Authorization.Command.Request
{
    public class UpdateUserRoleCommand : IRequest<string>
    {
        public UpdateUserRoleCommand(string userName,string oldRole, string role)
        {
            this.NewRole = role;
            this.OldRole = oldRole;
            this.userName = userName;
        }
        public string NewRole { set; get; }
        public string OldRole { set; get; }
        public string userName { set; get; }
    }

}
