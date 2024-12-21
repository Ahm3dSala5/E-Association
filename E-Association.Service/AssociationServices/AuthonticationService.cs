using Domain.DTOs.Users;
using Domain.Entities.Business;
using Domain.Entities.Securities;
using E_Association.Infrastructure.Presitence.Data;
using E_Association.Service.IAssociationServices.IBalanceServices;
using E_Association.Service.IAssociationServices.IEmailSender;
using E_Association.Service.IAssociationServices.Userservice;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SubScriptions.Infrastructure.Repositoty;

namespace E_Association.Service.AssociationServices.Userservice
{

    public class AuthonticationService : IAuthenticationService
    {
        private readonly IEmailSender _emailSender;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _config;
        private readonly IBalanceServices _balance;
        private AppDbContext _app;
       
        public AuthonticationService
            (AppDbContext app,IConfiguration config ,IEmailSender emailSender,UserManager<ApplicationUser> userManager ,IBalanceServices balance)
        {
            this._balance = balance;
            this._config = config;
            this._emailSender = emailSender;
            this._userManager = userManager;
            this._app = app;
        }

        public async ValueTask<string> RegistrantionAsync(RegistrationDTO register)
        {
            Balance balance = new Balance() { Amount = 0 };
            await _balance.CreateBalanceAsync(balance);
           
            var applicationUser = new ApplicationUser
            {
                UserName = register.UserName,
                Email = register.Email,
                Address = register.Address,
                PasswordHash = register.Password,
                BalanceId = balance.Id,
            };

            var creationResult = await _userManager.CreateAsync(applicationUser, register.Password);
            if (!creationResult.Succeeded)
                return creationResult.Errors.ToString()!;

           return await TokenHelper.GenerateVerificationCode(_emailSender,_userManager,applicationUser);
        }

        public async ValueTask<object> ConfirmUserAccountAsync(ConfirmEmailDTO confirm)
        {
            var user = await _userManager.FindByNameAsync(confirm.UserName);
            if (user is null)
                return ("InValid Confirmation");

            var storedCode = await _userManager.GetAuthenticationTokenAsync
                (user, "EmailConfirmation", "ConfirmationCode");

            if (storedCode != confirm.ConfirmationCode)
                return ("Invalid Confirmation Code");

            await _userManager.IsEmailConfirmedAsync(user);
            return TokenHelper.GenerateToken(_config,user);
        }

        public async ValueTask<object> LoginAsync(LoginDtO _user)
        {
            var user = await _userManager.FindByEmailAsync(_user.Email);
            if (user is null)
                throw new Exception("User Not Found");

            var cheeckPassword = await _userManager.CheckPasswordAsync(user, _user.Password);
            if(!cheeckPassword)
                throw new Exception("Invalid Password");
            
           return TokenHelper.GenerateToken(_config, user);
        }

        public async ValueTask<string> ChangePasswordAsync(ChangePasswordDTO changepasswprd)
        {
            var user = await _userManager.FindByEmailAsync(changepasswprd.Email);
            if (user is null)
                return "User Not Found or InValid Password";

            if(user.PasswordHash != changepasswprd.oldPassword)
                return "User Not Found or InValid Password";

            var changing = await _userManager.ChangePasswordAsync
                          (user,changepasswprd.oldPassword,changepasswprd.newPassword);

            if (!changing.Succeeded)
                string.Join(' ', changing.Errors.Select(error => error.Description));
            return "Password Change Suceesfuly";
        }

        public async ValueTask<string> GeneratePasswordResetCode (string email)
        {
            if (email is null)
                throw new Exception("Invalid Email");
            
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null)
                throw new Exception("Invalid Email");
            return await TokenHelper.GenerateVerificationCode(_emailSender,_userManager,user);

        }

        public async ValueTask<object> ForgetPassword(ForgetPasswordDTO _user)
        {
            if (_user is null)
                throw new Exception("Invalid Data");

            var user = await _userManager.FindByEmailAsync(_user.Email);
            if (user is null)
                throw new Exception("Invalid Data");

            var storedCode = await _userManager.GetAuthenticationTokenAsync
                (user, "EmailConfirmation", "ConfirmationCode");

            if(storedCode != _user.verificationCode)
                throw new Exception("Invalid Code");

           var changing = await _userManager.ChangePasswordAsync(user,user.PasswordHash,_user.NewPassword);
            
            return changing.Succeeded ? "Password Change Successfuly" :
                 string.Join(' ',changing.Errors.Select(x=>x.Description));
        }

        public async ValueTask<string> DeleteUserAsync(string UserName)
        {
            var user = await _userManager.FindByNameAsync(UserName);
            if (user is null)
                return "user Not Found";

            var deletion = await _userManager.DeleteAsync(user);
            if (!deletion.Succeeded)
                return string.Join(' ',deletion.Errors.Select(error=>error.Description));
            
            return "User Deleted Successfuly";
        }
    }
}