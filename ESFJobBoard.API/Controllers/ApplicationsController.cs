using ESFJobBoard.API.DAO;
using ESFJobBoard.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace ESFJobBoard.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationsController : ControllerBase
    {
        private readonly JobBoardDbContext _dbContext;

        public ApplicationsController(JobBoardDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetApplications()
        {
            var applications = _dbContext.Applications.ToList();
            return Ok(applications);
        }

        [HttpPost]
        public IActionResult ApplyForJob([FromBody] JobApplication application)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Applications.Add(application);
                _dbContext.SaveChanges();
                return CreatedAtAction(nameof(GetApplications), new { id = application.Id }, application);
            }

            return BadRequest(ModelState);
        }
    }
}