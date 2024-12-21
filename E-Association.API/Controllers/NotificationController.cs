using E_Association.Core.Features.Notification.Command.Request;
using E_Association.Core.Features.Notification.Query.Handler;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Association.API.Controllers
{
    [ApiController]
    [Route("api/notifications")]
    public class NotificationController : ControllerBase
    {
        private IMediator _mediator;
        public NotificationController(IMediator mediator)
        {
            this._mediator = mediator; 
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(string content)
        {
            return Ok(await _mediator.Send(new CreateNotificationCommand(content)));
        }

        [HttpPost("SendToUser/id")]
        public async Task<IActionResult> SendToUser(string title, string content,Guid userId)
        {
            return Ok(await _mediator.Send(new SendNotificationToUserCommand(title, content,userId)));
        }

        [HttpPost("SendToAllUsers")]
        public async Task<IActionResult> SendToAllUsers(string title,string content)
        {
            return Ok(await _mediator.Send(new SendNotificationToAllUserCommand(title,content)));
        }

        [HttpPost("SendToAssociationConsumer")]
        public async Task<IActionResult> SendToAssociationConsumer(string title, string content,string AssociationName)
        {
            return Ok(await _mediator.Send(new SendNotificationToAssociationConsumersCommand(title, content,AssociationName)));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> SendToAssociationConsumer(Guid _notificationId, string _newMessage)
        {
            return Ok(await _mediator.Send(new UpdateNotificationCommand(_notificationId, _newMessage)));
        }

        [HttpGet("GetUserNotifications/{username}")]
        public async Task<IActionResult> GetUserNotifications(string userName)
        {
            return Ok(await _mediator.Send(new GetUserNotificationQuery(userName)));
        }

        [HttpGet("GetAssociationNotifications/{associationname}")]
        public async Task<IActionResult> GetAssociationNotifications(string associationName)
        {
            return Ok(await _mediator.Send(new GetAssociationNotificationsQuery(associationName)));
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Create(Guid id)
        {
            return Ok(await _mediator.Send(new DeleteNotificationCommand(id)));
        }

    }
}
