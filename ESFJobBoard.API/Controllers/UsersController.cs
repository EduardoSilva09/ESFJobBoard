using ESFJobBoard.Application.Commands.CreateUser;
using ESFJobBoard.Application.Commands.DeleteUser;
using ESFJobBoard.Application.Commands.UpdateUser;
using ESFJobBoard.Application.Queries.GetUserById;
using ESFJobBoard.Application.Queries.GetUsers;
using ESFJobBoard.Core.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ESFJobBoard.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var query = new GetUsersQuery();
            var users = await _mediator.Send(query);

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var query = new GetUserByIdQuery { UserId = id };
            var user = await _mediator.Send(query);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] CreateUserCommand command)
        {
            var userId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetUserById), new { id = userId }, userId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserCommand command)
        {
            command.UserId = id;
            try
            {
                await _mediator.Send(command);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var command = new DeleteUserCommand { UserId = id };
            try
            {
                await _mediator.Send(command);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}