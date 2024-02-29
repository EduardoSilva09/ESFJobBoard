using ESFJobBoard.Application.Commands.CreateJobApplication;
using ESFJobBoard.Application.Commands.UpdateJobApplication;
using ESFJobBoard.Application.Commands.WithdrawJobApplication;
using ESFJobBoard.Application.Queries.GetAllJobApplications;
using ESFJobBoard.Application.Queries.GetApplicationsByJobId;
using ESFJobBoard.Application.Queries.GetApplicationsByJobSeekerId;
using ESFJobBoard.Application.Queries.GetJobApplicationById;
using ESFJobBoard.Core.Entities;
using ESFJobBoard.Core.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ESFJobBoard.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApplicationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<JobApplication>>> GetAllApplications()
        {
            var query = new GetAllJobApplicationsQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JobApplication>> GetApplicationById(int id)
        {
            var query = new GetJobApplicationByIdQuery { ApplicationId = id };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("job/{jobId}")]
        public async Task<IActionResult> GetApplicationsByJobId(int jobId)
        {
            var query = new GetApplicationsByJobIdQuery { JobId = jobId };
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("jobseeker/{jobSeekerId}")]
        public async Task<IActionResult> GetApplicationsByJobSeekerId(int jobSeekerId)
        {
            var query = new GetApplicationsByJobSeekerIdQuery { JobSeekerId = jobSeekerId };
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostApplication([FromBody] CreateJobApplicationCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return CreatedAtAction(nameof(GetApplicationById), new { id = result }, result);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateApplication(int id, [FromBody] UpdateJobApplicationCommand command)
        {
            command.ApplicationId = id;

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
        public async Task<IActionResult> DeleteApplication(int id)
        {
            var command = new WithdrawJobApplicationCommand { ApplicationId = id };

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