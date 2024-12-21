using E_Association.Core.Features.Payments.Query.Model;
using MediatR;

namespace E_Association.Core.Features.Payments.Query.Handler
{
    public class GetAssociationPaymentQuery : IRequest<List<PaymentModel>>
    {
        public GetAssociationPaymentQuery(Guid associatioId)
        {
            this.Id = associatioId;
        }
        public Guid Id { set; get; }
    }
}
