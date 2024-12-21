using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace E_Association.Core.Features.Authorization.Query.Request
{
    public class GetUserRolQuery : IRequest<string>
    {
        public GetUserRolQuery(string userName)
        {

            this.UserName = userName;
        }
        public string UserName { set; get; }
    }
}
