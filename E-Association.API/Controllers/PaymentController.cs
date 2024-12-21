using E_Association.Core.Features.Balances.Query.Request;
using E_Association.Core.Features.Payments.Command.Request;
using E_Association.Core.Features.Payments.Query.Handler;
using E_Association.Infrastructure.Domain.DTOs.Payments;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Association.API.Controllers
{
    [ApiController]
    [Route("api/payment")]
    public class PaymentController : ControllerBase
    {
        private IMediator _mediator;
        public PaymentController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("startPay")]
        public async Task<IActionResult> StartPay(Guid userId, decimal amount, Guid associationId)
        {
            return Ok(await _mediator.Send(new StartPaymentCommand(userId,amount,associationId)));
        }

        [HttpPut("updatePayment")]
        public async Task<IActionResult> UpdatePayment(UpdatePaymentDTO _payment)
        {
            return Ok(await _mediator.Send(new UpdatePaymentCommand(_payment)));
        }

        [HttpGet("GetUserPayments/{id}")]
        public async Task<IActionResult> GetUserPayments(Guid _userId)
        {
            return Ok(await _mediator.Send(new GetUserBalanceQuery(_userId)));
        }

        [HttpGet("GetAssociationPayments/{id}")]
        public async Task<IActionResult> GetAssociationPayments(Guid _associationid)
        {
            return Ok(await _mediator.Send(new GetAssociationPaymentQuery(_associationid)));
        }

        [HttpDelete("CancellationPayment/{id}")]
        public async Task<IActionResult> CancellationPayment(Guid _paymentId)
        {
            return Ok(await _mediator.Send(new CancellationPaymentCommand(_paymentId)));
        }
    }
}
