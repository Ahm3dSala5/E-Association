using Domain.DTOs.Users;
using MediatR;

namespace Application.Requests.User.Commands.Queries
{
    public class ChangeUserPasswordCommand : IRequest<string>
    {
        public ChangeUserPasswordCommand(ChangePasswordDTO user)
        {
            _Email = user.Email;
            _newPassword = user.newPassword;
            _confirmNewPassword = user.confirmNewPassword;
            _oldPassword = user.oldPassword;
        }
        public string _Email { set; get; }
        public string _oldPassword { set; get; }
        public string _newPassword { set; get; }
        public string _confirmNewPassword { set; get; }
    }
   
}
