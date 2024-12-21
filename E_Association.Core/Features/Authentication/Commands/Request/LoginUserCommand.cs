using Domain.DTOs.Users;
using MediatR;

namespace Application.Requests.User.Commands.Queries
{
    public class LoginUserCommand : IRequest<object>
    {
        public LoginUserCommand(LoginDtO login)
        {
            this.Email = login.Email;
            this.Password = login.Password;
        }
        public string Email { set; get; }
        public string Password { set; get; }
    }
   
}
