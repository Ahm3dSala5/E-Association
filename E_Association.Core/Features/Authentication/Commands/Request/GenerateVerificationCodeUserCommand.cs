using MediatR;
using System.Security.Cryptography.X509Certificates;

namespace Application.Requests.User.Commands.Queries
{
    public class GenerateVerificationCodeUserCommand : IRequest<string>
    {
        public GenerateVerificationCodeUserCommand(string email) 
        {
            this.Email = email;
        }
        public string Email { get; set; }   
    }
   
}
