using AutoMapper;
using Domain.Entities.Business;
using E_Association.Core.Application.Features.Transactions.Commands.Query;
using E_Association.Core.Features.Withdrawal.Command.Request;

namespace E_Association.Core.Mapping.Withdrawal
{
    public partial class WithdrawalProfile 
    {
        public void AddUpdatewithdrawalsMapping()
        {
            CreateMap<Withdrawals, UpdateWithdrawalCommand>();
        }
    }
}
