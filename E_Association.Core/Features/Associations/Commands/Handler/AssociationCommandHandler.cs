using AutoMapper;
using Domain.Entities.Business;
using E_Association.Core.Features.Associations.Commands.Request;
using E_Association.Service.IAssociationServices.IEmailSender;
using E_Association.Service.IAssociationServices.Userservice;
using E_Association.Service.UnitOfWorks;
using MediatR;

namespace E_Associations.Core.Features.Associations.Command.Handler
{
    public class AssociationCommandHandler :
         IRequestHandler<CreateAssociationCommand, string>,
         IRequestHandler <DeleteAssociationCommand,string>,
         IRequestHandler<UpdateAssociationCommand,string>,
         IRequestHandler<ApplyToAssociationCommand,string>
    {
        private IMapper _mapper;
        private IAssociationService _service;
        private readonly IEmailSender emailSender;

        public AssociationCommandHandler(IMapper mapper,IAssociationService service,IEmailSender emailSender)
        {
            _mapper=mapper;
            _service = service;
            this.emailSender = emailSender;
        }

        public async Task<string> Handle(CreateAssociationCommand request, CancellationToken cancellationToken)
        {
            var assoication = _mapper.Map<Association>(request);
            return await _service.CreateAssociationAsync(assoication);
        }

        public async Task<string> Handle(DeleteAssociationCommand request, CancellationToken cancellationToken)
        {
            return await _service.DeleteSubscriptionAsync(request.Name);
        }

        public async Task<string> Handle(ApplyToAssociationCommand request, CancellationToken cancellationToken)
        {
            return await _service.ApplyToAssociation(request.applicantName,request.associationName,request.getCashInMonth);   
        }

        public async Task<string> Handle(UpdateAssociationCommand request, CancellationToken cancellationToken)
        {
            var association = _mapper.Map<Association>(request);
            return await _service.UpdateSubscriptionAsync(association);
        }
    }
}