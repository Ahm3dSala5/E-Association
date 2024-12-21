using AutoMapper;

namespace E_Association.Core.Mapping.Withdrawal
{
    public partial class WithdrawalProfile : Profile
    {
        public WithdrawalProfile()
        {
            AddUpdatewithdrawalsMapping();
            AddGetWithdrawalsDetailsMapping();
            AddGetAllwithdrawalsMapping();
            AddGetUserwithdrawalsMapping();
        }
    }
}
