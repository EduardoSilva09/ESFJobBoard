using ESFJobBoard.Application.Commands.CreateJob;
using ESFJobBoard.Application.Commands.DeleteJob;
using ESFJobBoard.Application.Commands.UpdateJob;
using ESFJobBoard.Application.Queries.GetAllJobs;
using ESFJobBoard.Application.Queries.GetJobById;
using ESFJobBoard.Core.Entities;
using ESFJobBoard.Core.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ESFJobBoard.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JobsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetJobs()
        {
            var query = new GetAllJobsQuery();
            var jobs = await _mediator.Send(query);
            return Ok(jobs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobById(int id)
        {
            var query = new GetJobByIdQuery { JobId = id };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> PostJob([FromBody] Job job)
        {
            var command = new CreateJobCommand { Job = job };
            var jobId = await _mediator.Send(command);
            return Ok(jobId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJob(int id, [FromBody] UpdateJobCommand command)
        {
            command.JobId = id;

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
        public async Task<IActionResult> DeleteJob(int id)
        {
            var command = new DeleteJobCommand { JobId = id };

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