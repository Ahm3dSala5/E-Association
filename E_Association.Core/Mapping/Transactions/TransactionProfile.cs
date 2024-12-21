using AutoMapper;

namespace E_Association.Core.Mapping.Transaction
{
    public partial class BalanceProfile : Profile
    {
        public BalanceProfile()
        {
            AddStartTransactionMapping();
            AddUpdateTransactionMapping();
            AddGetTransactionByIdMapping();
            AddGetAllTransactionMapping();
            AddGetUserTransactionMapping();
        }
    }
}
