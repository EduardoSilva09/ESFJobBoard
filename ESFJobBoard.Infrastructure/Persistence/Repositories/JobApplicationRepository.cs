using ESFJobBoard.Core.Entities;
using ESFJobBoard.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace ESFJobBoard.Infrastructure.Persistence.Repositories
{
    public class JobApplicationRepository : IJobApplicationRepository
    {
        private readonly JobBoardDbContext _dbContext;

        public JobApplicationRepository(JobBoardDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<JobApplication>> GetApplicationsAsync()
        {
            return await _dbContext.Applications.ToListAsync();
        }

        public async Task<IEnumerable<JobApplication>> GetApplicationsByJobIdAsync(int jobId)
        {
            return await _dbContext.Applications
                .Where(application => application.JobId == jobId)
                .ToListAsync();
        }

        public async Task<IEnumerable<JobApplication>> GetApplicationsByJobSeekerIdAsync(int jobSeekerId)
        {
            return await _dbContext.Applications
                .Where(application => application.JobSeekerId == jobSeekerId)
                .ToListAsync();
        }

        public async Task<JobApplication?> GetJobApplicationAsync(int applicationId)
        {
            return await _dbContext.Applications.FindAsync(applicationId);
        }

        public async Task AddJobApplicationAsync(JobApplication jobApplication)
        {
            _dbContext.Applications.Add(jobApplication);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateJobApplicationAsync(JobApplication jobApplication)
        {
            _dbContext.Applications.Update(jobApplication);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteJobApplicationAsync(int applicationId)
        {
            var applicationToRemove = await _dbContext.Applications.FindAsync(applicationId);
            if (applicationToRemove != null)
            {
                _dbContext.Applications.Remove(applicationToRemove);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}