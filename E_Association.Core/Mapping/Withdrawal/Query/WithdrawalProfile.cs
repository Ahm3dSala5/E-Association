using Domain.Entities.Business;
using E_Association.Core.Features.Transactions.Queries.Request;
using E_Association.Core.Features.Withdrawal.Query.Request;

namespace E_Association.Core.Mapping.Withdrawal
{
    public partial class WithdrawalProfile
    {
        public void AddGetUserwithdrawalsMapping()
        {
            CreateMap<Withdrawals,GetUserWithdrawalsQuery>();
        }

        public void AddGetAllwithdrawalsMapping()
        {
            CreateMap<Withdrawals, GetAllWithdrawalsQuery>();
        }

        public void AddGetWithdrawalsDetailsMapping()
        {
            CreateMap<Withdrawals, GetWithdrawalDetailsQuery>();
        }
    }
}
