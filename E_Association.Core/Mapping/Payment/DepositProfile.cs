using AutoMapper;

namespace E_Association.Core.Mapping.Payments
{
    public partial class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            AddStartPaymentMapping();
            AddUpdatePaymentMapping();
            AddCancellationPaymentMapping();
            AddGetUserPaymentMapping();
            AddGetAssociationPaymentMapping();
        }
    }
}
