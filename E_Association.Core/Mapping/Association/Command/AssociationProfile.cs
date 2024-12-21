using Domain.DTOs.Subscriptions;
using Domain.Entities.Business;
using E_Association.Core.Features.Associations.Commands.Request;
using E_Association.Core.Features.Transactions.Queries.Request;
using E_Association.Core.Features.Withdrawal.Query.Request;

namespace E_Associations.Core.Mapping.Associations
{
    public partial class AssociationProfile
    {
        public void AddCreateAssociationMapping()
        {
            CreateMap<CreateAssociationCommand, Association>()
               .ForMember(x => x.Name, x => x.MapFrom(x => x.Name))
               .ForMember(x => x.MonthlyAmount, x => x.MapFrom(x => x.Amount))
               .ForMember(x => x.Status, x => x.MapFrom(x => x.state))
               .ForMember(x => x.StartAt, x => x.MapFrom(x => x.StartAt))
               .ForMember(x => x.EndAt, x => x.MapFrom(x => x.EndAt))
               .ForMember(x => x.Capacity, x => x.MapFrom(x => x.Capacity));
        }

        public void AddUpdateAssociationMapping()
        {
            CreateMap<UpdateAssociationCommand, Association>()
            .ForMember(x => x.Name, x => x.MapFrom(x => x.Name))
               .ForMember(x => x.MonthlyAmount, x => x.MapFrom(x => x.Amount))
               .ForMember(x => x.Status, x => x.MapFrom(x => x.state))
               .ForMember(x => x.StartAt, x => x.MapFrom(x => x.StartAt))
               .ForMember(x => x.EndAt, x => x.MapFrom(x => x.EndAt))
               .ForMember(x => x.Capacity, x => x.MapFrom(x => x.Capacity));
        }
    }
}
