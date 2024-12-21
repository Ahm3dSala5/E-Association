using MediatR;

namespace E_Association.Core.Features.Withdrawal.Command.Request
{
    public class CalncelationWithdrwalCommand :IRequest<string>
    {
        public CalncelationWithdrwalCommand(Guid id)
        {
            this.Id = id;
        }
        public Guid Id { get; set; }
    }
}
