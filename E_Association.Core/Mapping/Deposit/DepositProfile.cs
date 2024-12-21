using AutoMapper;

namespace E_Association.Core.Mapping.Deposits
{
    public partial class DepositProfile : Profile
    {
        public DepositProfile()
        {
            AddStartDepositMapping();
            AddDeleteDepositMapping();
            AddUpdateDepositMapping();
            AddGetDepositDetailsMapping();
            AddGetAllDepositsMapping();
            AddGetUserDepositsMapping();
        }
    }
}
