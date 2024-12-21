using AutoMapper;
using E_Association.Core.Features.Deposit.Commands.Handler;
using E_Association.Core.Features.Deposit.Queries.request;
using E_Association.Service.UnitOfWorks;
using MediatR;

namespace E_Association.Core.Features.Deposit.Queries.Handler
{
    public class DepositQueriesHandler :
        IRequestHandler<GetDepositDetailsQuery,DepositModel> ,
        IRequestHandler<GetUserDepositQuery,List<DepositModel>> ,
        IRequestHandler<GetAllDepositsQuery,List<DepositModel>> 
    {
        private IUnitOfWork _service;
        private IMapper _mapper;
        public DepositQueriesHandler(IUnitOfWork service,IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        public async Task<DepositModel> Handle(GetDepositDetailsQuery request, CancellationToken cancellationToken)
        {
            var deposit = await _service.Deposit.GetDepositDetails(request.DepositId);
            var depositMapped = _mapper.Map<DepositModel>(deposit);
            return depositMapped;
        }

        public async Task<List<DepositModel>> Handle(GetUserDepositQuery request, CancellationToken cancellationToken)
        {
            var deposit = await _service.Deposit.GetUserDeposits(request.UserName);
            var depositMapped = _mapper.Map<List<DepositModel>>(deposit);
            return depositMapped;
        }

        public async Task<List<DepositModel>> Handle(GetAllDepositsQuery request, CancellationToken cancellationToken)
        {
            var deposit = await _service.Deposit.GetAllDeposits();
            var depositMapped = _mapper.Map<List<DepositModel>>(deposit);
            return depositMapped;
        }
    }
}
