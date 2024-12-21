using AutoMapper;
using E_Association.Core.Features.Payments.Query.Model;
using E_Association.Service.UnitOfWorks;
using MediatR;

namespace E_Association.Core.Features.Payments.Query.Handler
{
    public class PaymentQueryHandler :
        IRequestHandler<GetUserPaymentsQuery, List<PaymentModel>>,
        IRequestHandler<GetAssociationPaymentQuery, List<PaymentModel>>

    {
        private IUnitOfWork _service;
        private IMapper _mapper;
        public PaymentQueryHandler(IUnitOfWork service, IMapper mapper)
        {
            this._service = service;    
            this._mapper = mapper;  
        }
        public async Task<List<PaymentModel>> Handle(GetUserPaymentsQuery request, CancellationToken cancellationToken)
        {
            var userPayments = await _service.Patment.GetUserPayments(request.userId);
            var userPaymentsMapped = _mapper.Map<List<PaymentModel>>(userPayments);
            return userPaymentsMapped;
        }

        public async Task<List<PaymentModel>> Handle(GetAssociationPaymentQuery request, CancellationToken cancellationToken)
        {
            var userPayments = await _service.Patment.GetUserPayments(request.Id);
            var userPaymentsMapped = _mapper.Map<List<PaymentModel>>(userPayments);
            return userPaymentsMapped;
        }
    }
}
