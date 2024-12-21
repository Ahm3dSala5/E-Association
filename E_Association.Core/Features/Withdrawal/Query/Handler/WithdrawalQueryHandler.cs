using AutoMapper;
using E_Association.Core.Features.Withdrawal.Query.Models;
using E_Association.Core.Features.Withdrawal.Query.Request;
using E_Association.Service.UnitOfWorks;
using MediatR;

namespace E_Association.Core.Features.Withdrawal.Query.Handler
{
    public class WithdrawalQueryHandler :
        IRequestHandler<GetUserWithdrawalsQuery, List<WithdrawalModel>>,
        IRequestHandler<GetAllWithdrawalsQuery, List<WithdrawalModel>>,
        IRequestHandler<GetWithdrawalDetailsQuery, WithdrawalModel>
    {
        private IMapper _mapper;
        private IUnitOfWork _service;
        public WithdrawalQueryHandler(IUnitOfWork service ,IMapper mapper)
        {
            this._mapper = mapper;
            this._service = service;
        }
        public async Task<List<WithdrawalModel>> Handle(GetUserWithdrawalsQuery request, CancellationToken cancellationToken)
        {
            var userwithdrawal = await _service.WithdrawalsService.GetUserWithdrawals(request.userId);
            return _mapper.Map<List<WithdrawalModel>>(userwithdrawal);
        }

        public async Task<List<WithdrawalModel>> Handle(GetAllWithdrawalsQuery request, CancellationToken cancellationToken)
        {
            var withdrawals = await _service.WithdrawalsService.GetAllWithdrawals();
            return _mapper.Map<List<WithdrawalModel>>(withdrawals);
        }

        public async Task<WithdrawalModel> Handle(GetWithdrawalDetailsQuery request, CancellationToken cancellationToken)
        {
            var withdrawals = await _service.WithdrawalsService.GetWithdrawalDetails(request.Id);
            return _mapper.Map<WithdrawalModel>(withdrawals);
        }
    }
}
