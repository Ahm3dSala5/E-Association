using E_Association.Core.Features.Payments.Query.Model;
using MediatR;

namespace E_Association.Core.Features.Payments.Query.Handler
{
    public class GetUserPaymentsQuery : IRequest<List<PaymentModel>>
    {
        public GetUserPaymentsQuery(Guid userId)
        {
            this.userId = userId;
        }   
        public Guid userId { set; get; }
    }
}
