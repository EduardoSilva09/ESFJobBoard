using ESFJobBoard.Core.Entities;
using ESFJobBoard.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace ESFJobBoard.Infrastructure.Persistence.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly JobBoardDbContext _dbContext;

        public JobRepository(JobBoardDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Job?> GetJobByIdAsync(int jobId)
        {
            return await _dbContext.Jobs.FindAsync(jobId);
        }

        public async Task<IEnumerable<Job>> GetJobsAsync()
        {
            return await _dbContext.Jobs.ToListAsync();
        }

        public async Task<int> AddJobAsync(Job job)
        {
            _dbContext.Jobs.Add(job);
            await _dbContext.SaveChangesAsync();
            return job.Id;
        }

        public async Task UpdateJobAsync(Job job)
        {
            _dbContext.Jobs.Update(job);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteJobAsync(int jobId)
        {
            var jobToRemove = await _dbContext.Jobs.FindAsync(jobId);
            if (jobToRemove != null)
            {
                _dbContext.Jobs.Remove(jobToRemove);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}