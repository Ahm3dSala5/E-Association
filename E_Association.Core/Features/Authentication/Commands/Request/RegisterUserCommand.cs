using Domain.DTOs.Users;
using MediatR;

namespace Application.Requests.User.Commands.Queries
{
    public class RegisterUserCommand : IRequest<object> 
    {
        public string UserName { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public string ConfirmPassword { set; get; }
        public string Address { set; get; }
        public RegisterUserCommand(RegistrationDTO register)
        {
            UserName = register.UserName;
            Password = register.Password;
            ConfirmPassword = register.ConfirmPassword;
            Address = register.Address;
            Email = register.Email;
        }
    }
}
