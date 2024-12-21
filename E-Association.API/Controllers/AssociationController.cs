using Domain.DTOs.Subscriptions;
using E_Association.Core.Features.Association.Query;
using E_Association.Core.Features.Associations.Commands.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Association.API.Controllers
{
    [ApiController]
    [Route("api/Association")]
    public class E_AssociationController : ControllerBase
    {
        private IMediator _mediator;
        public E_AssociationController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(AssociationDTO association)
        {
            return Ok(await _mediator.Send(new CreateAssociationCommand(association)));
        }

        [HttpPost("Apply")]
        public async Task<IActionResult> Apply(ApplyAssociationDTO association)
        {
            return Ok(await _mediator.Send(new ApplyToAssociationCommand(association.ApplicantUserName, association.AssociationName, association.GetCashInMonth)));
        }

        [HttpGet("Paginate/{PerPage}/{pageNumber}")]
        public async Task<IActionResult> Paginate(int PerPage, int pageNumber)
        {
            return Ok(await _mediator.Send(new PaginatAssociationsQuery(PerPage, pageNumber)));
        }

        [HttpGet("GetConsumerThatParticipanteInAssociation")]
        public async Task<IActionResult> GetConsumerInAnyParticipation()
        {
            return Ok(await _mediator.Send(new GetAllConsumerThatParticipantInAssociationQuery()));
        }

        [HttpGet("GetOne/{name}")]
        public async Task<IActionResult> GetConsumerInAnyParticipation(string name)
        {
            return Ok(await _mediator.Send(new GetAssociationByIdQuery(name)));
        }

        [HttpGet("GetCurrentMonthCollector/{name}")]
        public async Task<IActionResult> GetCollectorForCurrentMonth(string name)
        {
            return Ok(await _mediator.Send(new GetAssociationCollectorForCurrentMonthQuery(name)));
        }

        [HttpGet("AssociationConsumer/{name}")]
        public async Task<IActionResult> AssociationConsumer(string name)
        {
            return Ok(await _mediator.Send(new GetAssociationConsumerByNameQuery(name)));
        }

        [HttpDelete("delete/{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            return Ok(await _mediator.Send(new DeleteAssociationCommand(name)));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(AssociationDTO association)
        {
            return Ok(await _mediator.Send(new UpdateAssociationCommand(association)));
        }
    }
}
