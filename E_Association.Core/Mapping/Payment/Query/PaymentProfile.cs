using Domain.Entities.Business;
using E_Association.Core.Features.Payments.Query.Handler;

namespace E_Association.Core.Mapping.Payments
{
    public partial class PaymentProfile
    {
        public void AddGetUserPaymentMapping()
        {
            CreateMap<Payment, GetUserPaymentsQuery>();
        }

        public void AddGetAssociationPaymentMapping()
        {
            CreateMap<Payment, GetAssociationPaymentQuery>();
        }
    }
}
