using Application.Requests.User.Commands.Queries;
using Domain.DTOs.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Association.API.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class AuthenticationController : ControllerBase
    {
        private IMediator _mediator;
        public AuthenticationController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegistrationDTO register)
        {
            return Ok(await _mediator.Send(new RegisterUserCommand(register)));
        }

        [HttpPost("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(ConfirmEmailDTO register)
        {
            return Ok(await _mediator.Send(new ConfirmUserCommand(register)));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDtO login)
        {
            return Ok(await _mediator.Send(new LoginUserCommand(login)));
        }

        [HttpPost("reset-password-VerificationCode")]
        public async Task<IActionResult> GeneratePasswordResetCode(string email)
        {
            return Ok(await _mediator.Send(new GenerateVerificationCodeUserCommand(email)));
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ForgetPasswordDTO forget)
        {
            return Ok(await _mediator.Send(new ForgetUserPasswordCommand(forget)));
        }

        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO changepassword)
        {
            return Ok(await _mediator.Send(new ChangeUserPasswordCommand(changepassword)));
        }

        [HttpDelete("{username}")]
        public async Task<IActionResult> DeleteUser(string username)
        {
            return Ok(await _mediator.Send(new DeleteUserCommand(username)));
        }
    }
}
