using AutoMapper;
using Domain.Entities.Business;
using E_Association.Core.Features.Withdrawal.Command.Request;
using E_Association.Service.UnitOfWorks;
using MediatR;

namespace E_Association.Core.Features.Withdrawal.Command.Handler
{
    public class WithdrawalCommandHandler :
        IRequestHandler<StartWithdrawalCommand, string>,
        IRequestHandler<UpdateWithdrawalCommand, string>,
        IRequestHandler<CalncelationWithdrwalCommand, string>
    {
        private IUnitOfWork _service;
        private IMapper _mapper;
        public WithdrawalCommandHandler(IUnitOfWork service,IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }
        public async Task<string> Handle(StartWithdrawalCommand request, CancellationToken cancellationToken)
        {
            return  await _service.WithdrawalsService.StartWithdrawal(request.userId,request.amount);
        }

        public async Task<string> Handle(UpdateWithdrawalCommand request, CancellationToken cancellationToken)
        {
           var withdrawal = _mapper.Map<Withdrawals>(request);
            return await _service.WithdrawalsService.Updatewithdrwals(withdrawal);
        }

        public async Task<string> Handle(CalncelationWithdrwalCommand request, CancellationToken cancellationToken)
        {
            return await _service.WithdrawalsService.CalncelationWithdrawal(request.Id);
        }
    }
}
