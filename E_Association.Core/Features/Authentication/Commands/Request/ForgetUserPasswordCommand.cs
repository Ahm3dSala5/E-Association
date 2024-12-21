using Domain.DTOs.Users;
using MediatR;

namespace Application.Requests.User.Commands.Queries
{
    public class ForgetUserPasswordCommand : IRequest<object>
    {
        public ForgetUserPasswordCommand(ForgetPasswordDTO _user)
        {
            this.Email = _user.Email;
            this.NewPassword = _user.NewPassword;
            this.verificationCode = _user.verificationCode;
        }
        public string Email { get; set; }
        public string verificationCode { set; get; }
        public string NewPassword { set; get; }
    }
   
}
