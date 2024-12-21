using AutoMapper;
using Domain.Entities.Business;
using E_Association.Core.Application.Features.Transactions.Commands.Query;

namespace E_Association.Core.Mapping.Transaction
{
    public partial class BalanceProfile 
    {
        public void AddStartTransactionMapping()
        {
            CreateMap<Transactions, StartTransactionCommand>();
        }

        public void AddUpdateTransactionMapping()
        {
            CreateMap<Transactions, UpdateTransactionCommand>();
        }
    }
}
