﻿using MediatR;

namespace E_Association.Core.Features.Authorization.Command.Request
{
    public class AssignRoleToUserCommand :IRequest<string>
    {
        public AssignRoleToUserCommand(string userName, string role)
        {
            this.Role = role;
            this.userName = userName;

        }
        public string Role { set; get; }
        public string userName { set; get; }
    }

}