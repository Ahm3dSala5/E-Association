using Domain.Entities.Business;
using E_Association.Core.Features.Deposit.Commands.Request;

namespace E_Association.Core.Mapping.Deposits
{
    public partial class DepositProfile 
    {
        public void AddStartDepositMapping()
        {
            CreateMap<Deposit,StartDepositCommand>();
        }

        public void AddDeleteDepositMapping()
        {
            CreateMap<Deposit,DeleteDepositCommand>();
        }

        public void AddUpdateDepositMapping()
        {
            CreateMap<Deposit,UpdateDepositCommand>();
        }
    }
}
