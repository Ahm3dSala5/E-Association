﻿using AutoMapper;

namespace E_Association.Core.Mapping.Balances
{
    public partial class BalanceProfile : Profile
    {
        public BalanceProfile()
        {
            AddCreateBalanceMapping();
            AddDeleteBalanceMapping();
            AddUpdateBalanceMapping();
            AddGetBalanceDetailsMapping();
            AddGetalanceTransactionsMapping();
            AddGetUserBalanceMapping();
        }
    }
}