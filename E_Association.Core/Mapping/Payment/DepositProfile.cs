using AutoMapper;

namespace E_Association.Core.Mapping.Payments
{
    public partial class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            AddUpdatePaymentMapping();
            AddGetUserPaymentMapping();
            AddGetAssociationPaymentMapping();
        }
    }
}
