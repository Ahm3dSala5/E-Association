using Domain.DTOs.Users;
using Domain.Entities.Securities;

namespace E_Association.Service.IAssociationServices.Userservice
{
    public interface IAuthenticationService 
    {
        ValueTask<string> RegistrantionAsync(RegistrationDTO register);
        ValueTask<object> ConfirmUserAccountAsync(ConfirmEmailDTO code);
        ValueTask<object> LoginAsync(LoginDtO login);
        ValueTask<string> GeneratePasswordResetCode (string email);
        ValueTask<object> ForgetPassword(ForgetPasswordDTO email);
        ValueTask<string> ChangePasswordAsync(ChangePasswordDTO changepasswprd);
        ValueTask<string> DeleteUserAsync(string UserName);
       
        

    }
}
