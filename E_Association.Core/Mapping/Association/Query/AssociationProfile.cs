using Domain.DTOs.Subscriptions;
using Domain.Entities.Business;
using E_Association.Core.Features.Association.Query;

namespace E_Associations.Core.Mapping.Associations
{
    public partial class AssociationProfile
    {
        public void AddGetAssociationByIdMapping()
        {
            CreateMap<Association, AssociationDTO>()
                .ForMember(x => x.Name, x => x.MapFrom(x => x.Name))
                .ForMember(x => x.Amount, x => x.MapFrom(x => x.MonthlyAmount))
                .ForMember(x => x.state, x => x.MapFrom(x => x.Status))
                .ForMember(x => x.StatAt, x => x.MapFrom(x => x.StartAt))
                .ForMember(x => x.EndAt, x => x.MapFrom(x => x.EndAt));
        }

        public void AddPaginateAssociationMapping()
        {
            CreateMap<Association, AssociationDTO>()
                .ForMember(x => x.Name, x => x.MapFrom(x => x.Name))
                .ForMember(x => x.Amount, x => x.MapFrom(x => x.MonthlyAmount))
                .ForMember(x => x.state, x => x.MapFrom(x => x.Status))
                .ForMember(x => x.StatAt, x => x.MapFrom(x => x.StartAt))
                .ForMember(x => x.EndAt, x => x.MapFrom(x => x.EndAt));
        }

      
    }
}
