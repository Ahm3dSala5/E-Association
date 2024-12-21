using System.Transactions;
using Application.Respones;
using AutoMapper;
using Domain.Entities.Business;
using E_Association.Core.Application.Features.Transactions.Commands.Query;
using E_Association.Infrastructure.Domain.DTOs.Transactions;
using E_Association.Service.AssociationServices.Userservice;
using E_Association.Service.UnitOfWorks;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
namespace E_Association.Service.IAssociationServices.Userservice
{
    public class TransactionCommandHandler : ResponsesHandler
        , IRequestHandler<StartTransactionCommand, string>
        , IRequestHandler<DeleteTransactionCommand, string>
        , IRequestHandler<UpdateTransactionCommand, string>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _service;
        public TransactionCommandHandler(IUnitOfWork service,IMapper mapper)
        {
            this._mapper = mapper;
            this._service = service;
        }

        public async Task<string> Handle(StartTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = _mapper.Map<TransactionDTO>(request);
            return await _service.Transaction.StartTransaction(transaction);
        }

        public async Task<string> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {
            return await _service.Transaction.DeletAsync(request.Id);
        }

        public async Task<string> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = _mapper.Map<Transactions>(request);
            return await _service.Transaction.UpdateAsync(transaction);
        }
    }
}