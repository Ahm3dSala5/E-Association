using AutoMapper;
using Domain.Entities.Business;
using E_Association.Core.Features.Balances.Command.Request;
using E_Association.Service.UnitOfWorks;
using MediatR;

namespace E_Associations.Core.Features.Balances.Command.Handler
{
    public class BalanceCommandHandler :
        IRequestHandler<CreateBalanceCommand,string> ,
        IRequestHandler<DeleteBalanceCommand,string> ,
        IRequestHandler<UpdateBalanceCommand,string>
    {
        private IUnitOfWork _service;
        private IMapper _mapper;
        public BalanceCommandHandler(IUnitOfWork service,IMapper mapper)
        {
            this._mapper = mapper;
            this._service = service;
        }

        public async Task<string> Handle(CreateBalanceCommand request, CancellationToken cancellationToken)
        {
            var balance = _mapper.Map<Balance>(request);
            return await _service.BalanceServic.CreateBalanceAsync(balance);
        }

        public async Task<string> Handle(DeleteBalanceCommand request, CancellationToken cancellationToken)
        {
            return await _service.BalanceServic.DeleteUserBalance(request.id);
        }

        public async Task<string> Handle(UpdateBalanceCommand request, CancellationToken cancellationToken)
        {

            var balance = _mapper.Map<Balance>(request);
            return await _service.BalanceServic.UpdateUserPalanceAsync(balance);
        }
    }
}
