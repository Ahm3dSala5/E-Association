using Domain.DTOs.Users;
using MediatR;

namespace Application.Requests.User.Commands.Queries
{
    public class ConfirmUserCommand : IRequest<object>
    {
        public ConfirmUserCommand(ConfirmEmailDTO confirm)
        {
            this.UserName = confirm.UserName;
            this.ConfirmationCode = confirm.ConfirmationCode;
        }
        public string UserName { set; get; }
        public string ConfirmationCode { set; get; }
    }
}
