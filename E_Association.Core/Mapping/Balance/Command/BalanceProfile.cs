using AutoMapper;
using Domain.Entities.Business;
using E_Association.Core.Application.Features.Transactions.Commands.Query;
using E_Association.Core.Features.Balances.Command.Request;

namespace E_Association.Core.Mapping.Balances
{
    public partial class BalanceProfile 
    {
        public void AddCreateBalanceMapping()
        {
            CreateMap<Balance, CreateBalanceCommand>();
        }

        public void AddDeleteBalanceMapping()
        {
            CreateMap<Transactions,DeleteBalanceCommand>();
        }

        public void AddUpdateBalanceMapping()
        {
            CreateMap<Balance, UpdateBalanceCommand>();
        }
    }
}
