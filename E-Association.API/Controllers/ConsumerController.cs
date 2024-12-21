using Application.Requests.User.Commands.Queries;
using Domain.DTOs.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Association.API.Controllers
{
    [ApiController]
    [Route("api/consumer")]
    public class ConsumerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ConsumerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("paginate")]
        public IActionResult Paginate(int sizePerPage, int pageNumber)
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            return Ok();
        }
    }
}
