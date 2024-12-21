using Domain.Entities.Business;
using E_Association.Core.Features.Balances.Query.Request;
using E_Association.Core.Features.Transactions.Queries.Request;

namespace E_Association.Core.Mapping.Balances
{
    public partial class BalanceProfile 
    {
        public void AddGetBalanceDetailsMapping()
        {
            CreateMap<Balance, GetBalanceDetailsQuery>();
        }

        public void AddGetalanceTransactionsMapping()
        {
            CreateMap<Balance, GetBalanceTransactionsQuery>();
        }

        public void AddGetUserBalanceMapping()
        {
            CreateMap<Balance, GetUserBalanceQuery>();
        }
    }
}
