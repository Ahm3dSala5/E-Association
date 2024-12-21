using AutoMapper;
using Domain.DTOs.Subscriptions;
using Domain.Entities.Business;
using E_Association.Core.Features.Association.Query;
using E_Association.Service.IAssociationServices.Userservice;
using E_Association.Service.UnitOfWorks;
using MediatR;

namespace E_Associations.Core.Features.Associations.Query
{
    public class AssociationQueryHandler : 
        IRequestHandler<GetAssociationByIdQuery,AssociationDTO>,
        IRequestHandler<PaginatAssociationsQuery,List<AssociationDTO>> ,
        IRequestHandler<GetAssociationConsumerByNameQuery, List<string>> ,
        IRequestHandler<GetAssociationCollectorForCurrentMonthQuery, string> ,
        IRequestHandler<GetAllConsumerThatParticipantInAssociationQuery, List<string>> 
       
    {
        private readonly IAssociationService _service;
        private readonly IMapper _mapper;
        public AssociationQueryHandler(IAssociationService service, IMapper mapper)
        {
            this._mapper = mapper;
            this._service = service;
        }

        public async Task<AssociationDTO> Handle(GetAssociationByIdQuery request, CancellationToken cancellationToken)
        {
            var association = await _service.GetAssociationByName(request.Name);
            var associationMapped = _mapper.Map<AssociationDTO>(association);
            return associationMapped;
        }

        public async Task<List<AssociationDTO>> Handle(PaginatAssociationsQuery request, CancellationToken cancellationToken)
        {
            var associations = await _service.PaginatSubscriptions(request.pageSize, request.pageNumber);
            var assocationMapped = _mapper.Map<List<AssociationDTO>>(associations);

            return assocationMapped;
        }

        public async Task<List<string>> Handle(GetAssociationConsumerByNameQuery request, CancellationToken cancellationToken)
        {
           return await _service.GetAssociationConsumerByName(request.AssociationName);
        }

        public async Task<string> Handle(GetAssociationCollectorForCurrentMonthQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetCollectorForCurrentMonth(request.AssociatioName);
        }

        public async Task<List<string>> Handle(GetAllConsumerThatParticipantInAssociationQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetAllConsumerThatParticipantInAssociations(); 
        }
    }
}