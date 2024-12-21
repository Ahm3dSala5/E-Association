using E_Association.Core.Application.Features.Transactions.Commands.Query;
using E_Association.Core.Features.Transactions.Queries.Request;
using E_Association.Infrastructure.Domain.DTOs.Transactions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Association.API.Controllers
{
    [ApiController]
    [Route("api/transaction")]
    public class TransactionController : ControllerBase
    {
        private IMediator _mediator;
        public TransactionController(IMediator mediator)
        {
            this._mediator = mediator;  
        }

        [HttpPost("start")]
        public async Task<IActionResult> Start(TransactionDTO transaction)
        {
            return Ok(await _mediator.Send(new StartTransactionCommand(transaction)));
        }

        [HttpGet("GetOne/{id}")]
        public async Task<IActionResult> GetOne(Guid transactionid)
        {
            return Ok(await _mediator.Send(new GetTransactionByIdQuery(transactionid)));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllTransactionQuery()));
        }

        [HttpGet("GetUserTransaction/{id}")]
        public async Task<IActionResult> StartTransaction(Guid userId)
        {
            return Ok(await _mediator.Send(new GetUserTransactionsQuery(userId)));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateTransaction(TransactionDTO transaction)
        {
            return Ok(await _mediator.Send(new UpdateTransactionCommand(transaction)));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Guid transactionId)
        {
            return Ok(await _mediator.Send(new DeleteTransactionCommand(transactionId)));
        }
    }
}