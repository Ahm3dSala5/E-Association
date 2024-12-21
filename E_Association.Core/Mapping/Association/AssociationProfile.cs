using AutoMapper;

namespace E_Associations.Core.Mapping.Associations
{
    public partial class AssociationProfile : Profile
    {
        public AssociationProfile()
        {
            AddUpdateAssociationMapping();
            AddCreateAssociationMapping();
            AddGetAssociationByIdMapping();
            AddPaginateAssociationMapping();
        }
    }
}
