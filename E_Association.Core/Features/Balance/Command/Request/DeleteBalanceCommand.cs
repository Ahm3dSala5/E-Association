using MediatR;

namespace E_Association.Core.Features.Balances.Command.Request
{
    public class DeleteBalanceCommand :IRequest<string>
    {
        public DeleteBalanceCommand(Guid balanceId)
        {
            this.id = balanceId;
        }
        public Guid id { set; get; }
    }
}
