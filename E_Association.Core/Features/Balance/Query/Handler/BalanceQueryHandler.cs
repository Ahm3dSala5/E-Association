using AutoMapper;
using E_Association.Core.Features.Balances.Query.Request;
using E_Association.Core.Features.Balances.Query.Models;
using E_Association.Service.UnitOfWorks;
using MediatR;

namespace E_Association.Core.Features.Balances.Query.Handler
{
    public class BalanceQueryHandler :
        IRequestHandler<GetBalanceTransactionsQuery, List<BalanceTransactionDTO>> ,
        IRequestHandler<GetUserBalanceQuery,BalanceDTO>,
        IRequestHandler<GetBalanceDetailsQuery,BalanceDetailsDTO>
    {
        private IUnitOfWork _service;
        private IMapper _mapper;
        public BalanceQueryHandler(IUnitOfWork service,IMapper mapper)
        {
            this._mapper = mapper;
            this._service = service;
        }
      

        
        public async Task<BalanceDTO> Handle(GetUserBalanceQuery request, CancellationToken cancellationToken)
        {
            var balance = await _service.BalanceServic.GetUserBalance(request.userId);
            return _mapper.Map<BalanceDTO>(balance);
        }

        public async Task<BalanceDetailsDTO> Handle(GetBalanceDetailsQuery request, CancellationToken cancellationToken)
        {
            var balance = await _service.BalanceServic.GetBalanceDetails(request.BalanceId);
            return _mapper.Map<BalanceDetailsDTO>(balance);
        }

        public async Task<List<BalanceTransactionDTO>> Handle(GetBalanceTransactionsQuery request, CancellationToken cancellationToken)
        {
            var BalanceTransaction = await _service.BalanceServic.GetBalanceTransactions(request.BalanceId);
            return _mapper.Map<List<BalanceTransactionDTO>>(request);
        }
    }
}
