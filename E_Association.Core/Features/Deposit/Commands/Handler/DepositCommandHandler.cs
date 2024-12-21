using E_Association.Core.Features.Deposit.Commands.Request;
using E_Association.Service.UnitOfWorks;
using MediatR;

namespace E_Association.Core.Features.Deposit.Commands.Handlers
{

    public class DepositCommandHandler :
        IRequestHandler<StartDepositCommand,string> ,
        IRequestHandler<DeleteDepositCommand,string> ,
        IRequestHandler<UpdateDepositCommand,string>
    {
        private IUnitOfWork _service;
        public DepositCommandHandler(IUnitOfWork service)
        {
            this._service = service;
        }
        public async Task<string> Handle(StartDepositCommand request, CancellationToken cancellationToken)
        {
            return await _service.Deposit.StartDeposit(request.userId,request.Amount);
        }

        public async Task<string> Handle(DeleteDepositCommand request, CancellationToken cancellationToken)
        {
            return await _service.Deposit.DeleteDeposit(request.DepositeId);
        }

        public async Task<string> Handle(UpdateDepositCommand request, CancellationToken cancellationToken)
        {
            return await _service.Deposit.UpdateDeposit(request.Userid,request.Newamoutt,request.Depositid);
        }
    }
}
