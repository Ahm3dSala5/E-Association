using MediatR;

namespace E_Association.Core.Features.Deposit.Commands.Request
{
    public class DeleteDepositCommand : IRequest<string>
    {
        public DeleteDepositCommand(Guid depositeid)
        {
            this.DepositeId = depositeid;
        }
        public Guid DepositeId { set; get; }
    }
}
