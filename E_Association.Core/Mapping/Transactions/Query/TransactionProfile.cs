using Domain.Entities.Business;
using E_Association.Core.Features.Transactions.Queries.Request;

namespace E_Association.Core.Mapping.Transaction
{
    public partial class BalanceProfile 
    {
        public void AddGetTransactionByIdMapping()
        {
            CreateMap<Transactions, GetTransactionByIdQuery>();
        }

        public void AddGetAllTransactionMapping()
        {
            CreateMap<Transactions, GetAllTransactionQuery>();
        }

        public void AddGetUserTransactionMapping()
        {
            CreateMap<Transactions, GetUserTransactionsQuery>();
        }
    }
}
