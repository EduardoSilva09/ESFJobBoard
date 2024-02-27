using ESFJobBoard.Core.Entities;
using ESFJobBoard.Core.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ESFJobBoard.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly IJobRepository _jobRepository;

        public JobsController(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetJobs()
        {
            var jobs = await _jobRepository.GetJobsAsync();
            return Ok(jobs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobById(int id)
        {
            var job = await _jobRepository.GetJobByIdAsync(id);

            if (job == null)
            {
                return NotFound();
            }

            return Ok(job);
        }

        [HttpPost]
        public async Task<IActionResult> PostJob([FromBody] Job job)
        {
            if (ModelState.IsValid)
            {
                await _jobRepository.AddJobAsync(job);
                return CreatedAtAction(nameof(GetJobById), new { id = job.Id }, job);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJob(int id, [FromBody] Job job)
        {
            if (id != job.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _jobRepository.UpdateJobAsync(job);
                return NoContent();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(int id)
        {
            var existingJob = await _jobRepository.GetJobByIdAsync(id);

            if (existingJob == null)
            {
                return NotFound();
            }

            await _jobRepository.DeleteJobAsync(id);
            return NoContent();
        }
    }
}