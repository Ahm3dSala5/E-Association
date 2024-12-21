using E_Association.Core.Features.Withdrawal.Command.Request;
using E_Association.Core.Features.Withdrawal.Query.Request;
using E_Association.Infrastructure.Domain.DTOs.Withdrawal;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace E_Association.API.Controllers
{
    [ApiController]
    [Route("api/Withdrawal")]
    public class WithdrawalController : ControllerBase
    {
        private IMediator _mediaror;
        public WithdrawalController(IMediator mediator)
        {
            this._mediaror = mediator;
        }

        [HttpPost("start")]
        public async Task<IActionResult> StartWithdrawal(Guid userId, decimal amount)
        {
            return Ok(await _mediaror.Send(new StartWithdrawalCommand(userId,amount)));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(WithdrawalDTO withdrawal)
        {
            return Ok(await _mediaror.Send(new UpdateWithdrawalCommand(withdrawal)));
        }

        [HttpGet("GetOne/{id}")]
        public async Task<IActionResult> GetOne(Guid id)
        {
            return Ok(await _mediaror.Send(new GetWithdrawalDetailsQuery(id)));
        }

        [HttpGet("GetUserWithdrawal/{id}")]
        public async Task<IActionResult> GetUserWithdrawal(Guid id)
        {
            return Ok(await _mediaror.Send(new GetUserWithdrawalsQuery(id)));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediaror.Send(new GetAllWithdrawalsQuery()));
        }

        [HttpPost("Cancel/{id}")]
        public async Task<IActionResult> Cancel(Guid id)
        {
            return Ok(await _mediaror.Send(new CalncelationWithdrwalCommand(id)));
        }
    }
}
