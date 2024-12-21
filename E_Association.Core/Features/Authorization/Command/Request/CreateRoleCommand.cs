using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace E_Association.Core.Features.Authorization.Command.Request
{
    public class CreateRoleCommand : IRequest<string>
    {
        public CreateRoleCommand(string role)
        {
            this.Role = role;
        }
        public string Role { set; get; }
    }
}
