using ESFJobBoard.Core.Entities;
using ESFJobBoard.Core.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ESFJobBoard.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationsController : ControllerBase
    {
        private readonly IJobApplicationRepository _applicationRepository;

        public ApplicationsController(IJobApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetApplications()
        {
            var applications = await _applicationRepository.GetApplicationsAsync();
            return Ok(applications);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetApplicationById(int id)
        {
            var application = await _applicationRepository.GetJobApplicationAsync(id);

            if (application == null)
            {
                return NotFound();
            }

            return Ok(application);
        }

        [HttpGet("job/{jobId}")]
        public async Task<IActionResult> GetApplicationsByJobId(int jobId)
        {
            var applications = await _applicationRepository.GetApplicationsByJobIdAsync(jobId);
            return Ok(applications);
        }

        [HttpGet("jobseeker/{jobSeekerId}")]
        public async Task<IActionResult> GetApplicationsByJobSeekerId(int jobSeekerId)
        {
            var applications = await _applicationRepository.GetApplicationsByJobSeekerIdAsync(jobSeekerId);
            return Ok(applications);
        }

        [HttpPost]
        public async Task<IActionResult> PostApplication([FromBody] JobApplication application)
        {
            if (ModelState.IsValid)
            {
                await _applicationRepository.AddJobApplicationAsync(application);
                return CreatedAtAction(nameof(GetApplicationById), new { id = application.Id }, application);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateApplication(int id, [FromBody] JobApplication application)
        {
            if (id != application.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _applicationRepository.UpdateJobApplicationAsync(application);
                return NoContent();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplication(int id)
        {
            var existingApplication = await _applicationRepository.GetJobApplicationAsync(id);

            if (existingApplication == null)
            {
                return NotFound();
            }

            await _applicationRepository.DeleteJobApplicationAsync(id);
            return NoContent();
        }
    }
}