using AutoMapper;
using E_Association.Service.UnitOfWorks;
using MediatR;

namespace E_Association.Core.Features.Notification.Query.Handler
{
    public class NotificationQueryHandler
        : IRequestHandler<GetUserNotificationQuery, List<NotificationModel>>,
        IRequestHandler<GetAssociationNotificationsQuery, List<NotificationModel>>
    {
        private IUnitOfWork _service;
        private IMapper _mapper;
        public NotificationQueryHandler(IUnitOfWork service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }
        public async Task<List<NotificationModel>> Handle(GetAssociationNotificationsQuery request, CancellationToken cancellationToken)
        {
            var associationNotification = await _service.NotificationService.GetSubscriptionNotification(request.AssociationName);
            return _mapper.Map<List<NotificationModel>>(associationNotification);
        }

        public async Task<List<NotificationModel>> Handle(GetUserNotificationQuery request, CancellationToken cancellationToken)
        {
            var associationNotification = await _service.NotificationService.GetUserNotifications(request.userid);
            return _mapper.Map<List<NotificationModel>>(associationNotification);
        }
    }
}
