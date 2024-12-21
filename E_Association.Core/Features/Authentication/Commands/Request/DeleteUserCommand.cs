using MediatR;

namespace Application.Requests.User.Commands.Queries
{
    public class DeleteUserCommand : IRequest<string>
    {
        public DeleteUserCommand(string _username)
        {
            this.UserName = _username;
        }
        public string UserName { set; get; }
    }
   
}
