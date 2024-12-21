using AutoMapper;
using E_Association.Core.Application.Features.Transactions.Commands.Model;
using E_Association.Core.Features.Transactions.Queries.Model;
using E_Association.Core.Features.Transactions.Queries.Request;
using E_Association.Service.UnitOfWorks;
using MediatR;

namespace E_Association.Core.Features.Transactions.Queries.Handler
{
    public class TransactionQueryHandler :
        IRequestHandler<GetTransactionByIdQuery, TransactionModel> ,
        IRequestHandler<GetAllTransactionQuery, List<TransactionModel>> ,
        IRequestHandler<GetUserTransactionsQuery, List<TransactionModel>> 
    {
        private IUnitOfWork _service;
        private IMapper _mapper;
        public TransactionQueryHandler(IUnitOfWork service ,IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;  
        }
        public async Task<TransactionModel> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
        {
            var transaction =await _service.Transaction.GetOneByIdAsync(request.Id);
            var transactionMapped = _mapper.Map<TransactionModel>(transaction);
            return transactionMapped;
        }

        public async Task<List<TransactionModel>> Handle(GetAllTransactionQuery request, CancellationToken cancellationToken)
        {
            var transaction = await _service.Transaction.GetAllAsync();
            var transactionsMapped = _mapper.Map<List<TransactionModel>>(transaction);
            return transactionsMapped;
        }

        public async Task<List<TransactionModel>> Handle(GetUserTransactionsQuery request, CancellationToken cancellationToken)
        {
            var transaction = await _service.Transaction.GetUserTransaction(request.Id);
            var transactionsMapped = _mapper.Map<List<TransactionModel>>(transaction);
            return transactionsMapped;
        }
    }
}
