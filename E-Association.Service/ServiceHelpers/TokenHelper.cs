using Domain.Entities.Securities;
using E_Association.Service.IAssociationServices.IEmailSender;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SubScriptions.Infrastructure.Repositoty
{
    public static class TokenHelper
    {
        public static object GenerateToken(IConfiguration _config,Consumer user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _config["JWT:Issuer"],
                audience: _config["JWT:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(int.Parse(_config["JWT:Expire"]!)),
                signingCredentials: credentials
            );

            return new
            {
                Balance = "Balance Created Successuly",
                Confirmation = "Email Confirmed Successfuly",
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expire = token.ValidTo
            };
        }

        public static async ValueTask<string>  GenerateVerificationCode
            (IEmailSender _emailSender, UserManager<Consumer>_userManager,Consumer applicationUser)
        {

            var confirmationCode = new Random().Next(100000, 999999).ToString();

            await _userManager.SetAuthenticationTokenAsync(
                applicationUser,
                "EmailConfirmation",
                "ConfirmationCode",
                confirmationCode
            );

            var emailMessage = $@"
                <h1>Hello {applicationUser.UserName},</h1>
                <p>Thank you for registering with our application.</p>
                <p>Your verification code is:</p>
                <h2>{confirmationCode}</h2>
                <p>If you did not request this, please ignore this email.</p>
                <p>Thank you,<br>Your Application Team</p>
            ";

            await _emailSender.SendEmailAsync(applicationUser.Email!, "Email Confirmation Code", emailMessage);
            return "Check your email for a confirmation code to verify your account.";
        }
    }
}
