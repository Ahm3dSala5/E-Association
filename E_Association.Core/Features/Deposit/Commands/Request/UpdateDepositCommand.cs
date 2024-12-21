using MediatR;

namespace E_Association.Core.Features.Deposit.Commands.Request
{
    public class UpdateDepositCommand : IRequest<string>
    {
        public UpdateDepositCommand(Guid userid, decimal newamoutt, Guid depositid)
        {
            this.Userid = userid;
            this.Newamoutt = newamoutt;
            this.Depositid = depositid;
        }
        public Guid Userid { get; set; }
        public decimal Newamoutt { get; set; }
           
        public Guid Depositid { get; set; }
    }
}
