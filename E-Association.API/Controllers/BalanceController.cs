using E_Association.Core.Features.Balances.Command.Request;
using E_Association.Core.Features.Balances.Query.Models;
using E_Association.Core.Features.Balances.Query.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Association.API.Controllers
{
    [ApiController]
    [Route("api/balance")]
    public class BalanceController : ControllerBase
    {
        private IMediator _mediator;
        public BalanceController(IMediator mediaror)
        {
            this._mediator = mediaror;
        }

        [HttpPost("Create")]
        public async Task <IActionResult> Create( [FromBody] BalanceDTO balance)
        {
            return Ok(await _mediator.Send(new CreateBalanceCommand(balance)));
        }

        [HttpGet("GetBalanceTransactions/{id}")]
        public async Task<IActionResult> GetBalanceTransactions(Guid balanceid)
        {
            return Ok(await _mediator.Send(new GetBalanceTransactionsQuery(balanceid)));
        }

        [HttpGet("GetOne/{id}")]
        public async Task<IActionResult> GetOne(Guid id)
        {
            return Ok(await _mediator.Send(new GetBalanceDetailsQuery(id)));
        }

        [HttpGet("GetUserBalance/{id}")]
        public async Task<IActionResult> GetUserBalance(Guid id)
        {
            return Ok(await _mediator.Send(new GetUserBalanceQuery(id)));
        }

        // get all balances

        [HttpPut("UpdateBalance")]
        public async Task<IActionResult> GetUserBalance(BalanceDTO balance)
        {
            return Ok(await _mediator.Send(new UpdateBalanceCommand(balance)));
        }

        [HttpPut("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _mediator.Send(new DeleteBalanceCommand(id)));
        }
    }
}
