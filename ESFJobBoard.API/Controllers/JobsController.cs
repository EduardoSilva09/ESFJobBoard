using ESFJobBoard.API.DAO;
using ESFJobBoard.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace ESFJobBoard.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly JobBoardDbContext _dbContext;

        public JobsController(JobBoardDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetJobs()
        {
            var jobs = _dbContext.Jobs.ToList();
            return Ok(jobs);
        }

        [HttpPost]
        public IActionResult PostJob([FromBody] Job job)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Jobs.Add(job);
                _dbContext.SaveChanges();
                return CreatedAtAction(nameof(GetJobs), new { id = job.Id }, job);
            }

            return BadRequest(ModelState);
        }
    }
}