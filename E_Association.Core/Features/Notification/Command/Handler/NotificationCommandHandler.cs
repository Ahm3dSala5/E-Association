using AutoMapper;
using E_Association.Core.Features.Notification.Command.Request;
using E_Association.Service.UnitOfWorks;
using MediatR;

namespace E_Association.Core.Features.Notification.Command.Handler
{
    public class NotificationCommandHandler :
        IRequestHandler<CreateNotificationCommand, string> ,
        IRequestHandler<DeleteNotificationCommand, string> ,
        IRequestHandler<UpdateNotificationCommand, string> ,
        IRequestHandler<SendNotificationToUserCommand, string> ,
        IRequestHandler<SendNotificationToAllUserCommand, string> ,
        IRequestHandler<SendNotificationToAssociationConsumersCommand, string> 
    {
        private IMapper _mapper;
        private IUnitOfWork _service;
        public NotificationCommandHandler(IUnitOfWork service ,IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }
        public async Task<string> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            return await _service.NotificationService.CreateNotification(request.NotificationContent);
        }

        public async Task<string> Handle(UpdateNotificationCommand request, CancellationToken cancellationToken)
        {
            return await _service.NotificationService.UpdateNotification(request.NotificationId,request.newMessage);
        }

        public async Task<string> Handle(SendNotificationToAllUserCommand request, CancellationToken cancellationToken)
        {
            return await _service.NotificationService.SendToAllUsersAsync(request.Title,request.Message);
        }

        public async Task<string> Handle(SendNotificationToAssociationConsumersCommand request, CancellationToken cancellationToken)
        {
            return await _service.NotificationService.SendToSubscriptionUserAsync(request.Title,request.Message,request.associationName);
        }

        public async Task<string> Handle(SendNotificationToUserCommand request, CancellationToken cancellationToken)
        {
            return await _service.NotificationService.SendToUserAsync(request.Title,request.Message,request.UserId);
        }

        public async Task<string> Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
        {
            return await _service.NotificationService.DeleteNotification(request.notificationId);
        }
    }
}
