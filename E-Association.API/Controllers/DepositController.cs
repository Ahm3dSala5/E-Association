using System.Reflection.Metadata.Ecma335;
using E_Association.Core.Features.Deposit.Commands.Request;
using E_Association.Core.Features.Deposit.Queries.request;
using E_Association.Infrastructure.Domain.DTOs.Deposit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace E_Association.API.Controllers
{
    [ApiController]
    [Route("api/deposit")]
    public class DepositController : ControllerBase
    {
        private IMediator _mediator;
        public DepositController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("start/{userId,amount}")]
        public async Task<IActionResult> Start(Guid userId, decimal amount)
        {
            return Ok(await _mediator.Send(new StartDepositCommand(userId, amount)));
        }

        [HttpGet("GetDepositDetails/{id}")]
        public async Task<IActionResult> GetOne(Guid userId)
        {
            return Ok(await _mediator.Send(new GetDepositDetailsQuery(userId)));
        }

        [HttpGet("GetUserDeposits/{id}")]
        public async Task<IActionResult> GetUserDeposits(string userId)
        {
            return Ok(await _mediator.Send(new GetUserDepositQuery(userId)));
        }

        [HttpGet("GetAllDeposits")]
        public async Task<IActionResult> GetAllDeposits()
        {
            return Ok(await _mediator.Send(new GetAllDepositsQuery()));
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateDepositDTO deposit)
        {
            return Ok(await _mediator.Send(new UpdateDepositCommand(deposit.userId,deposit.Amount,deposit.depositId)));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _mediator.Send(new DeleteDepositCommand(id)));
        }
    }
}
