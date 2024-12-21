using Domain.Entities.Business;
using E_Association.Core.Features.Deposit.Queries.request;
using E_Association.Core.Features.Transactions.Queries.Request;

namespace E_Association.Core.Mapping.Deposits
{
    public partial class DepositProfile
    {
        public void AddGetDepositDetailsMapping()
        {
            CreateMap<Deposit, GetDepositDetailsQuery>();
        }

        public void AddGetAllDepositsMapping()
        {
            CreateMap<Deposit, GetAllDepositsQuery>();
        }

        public void AddGetUserDepositsMapping()
        {
            CreateMap<Deposit, GetUserDepositQuery>();
        }
    }
}
