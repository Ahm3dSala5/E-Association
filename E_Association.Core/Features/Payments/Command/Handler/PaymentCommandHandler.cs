using AutoMapper;
using E_Association.Core.Features.Payments.Command.Request;
using E_Association.Infrastructure.Domain.DTOs.Payments;
using E_Association.Service.UnitOfWorks;
using MediatR;

namespace E_Association.Core.Features.Payments.Command.Handler
{
    public class PaymentCommandHandler :
        IRequestHandler<StartPaymentCommand, string>,
        IRequestHandler<UpdatePaymentCommand, string>,
        IRequestHandler<CancellationPaymentCommand, string>
    {

        private IUnitOfWork _service;
        private IMapper _mapper;
        public PaymentCommandHandler(IUnitOfWork service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }
        public async Task<string> Handle(StartPaymentCommand request, CancellationToken cancellationToken)
        {
            return await _service.Patment.StartPaymentAsync(request.userId,request.amount,request.associationId);
        }

        public async Task<string> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
        {
            var paymet = _mapper.Map<UpdatePaymentDTO>(request);
            return await _service.Patment.UpdatePaymentAsync(paymet);
        }

        public async Task<string> Handle(CancellationPaymentCommand request, CancellationToken cancellationToken)
        {
            return await _service.Patment.CancellationPayment(request.PaymentId);
        }
    }
}
