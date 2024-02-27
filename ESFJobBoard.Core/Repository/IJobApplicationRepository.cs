using ESFJobBoard.Core.Entities;

namespace ESFJobBoard.Core.Repository
{
    public interface IJobApplicationRepository
    {
        Task<IEnumerable<JobApplication>> GetApplicationsAsync();
        Task<IEnumerable<JobApplication>> GetApplicationsByJobIdAsync(int jobId);
        Task<IEnumerable<JobApplication>> GetApplicationsByJobSeekerIdAsync(int jobSeekerId);
        Task<JobApplication?> GetJobApplicationAsync(int applicationId);
        Task AddJobApplicationAsync(JobApplication jobApplication);
        Task UpdateJobApplicationAsync(JobApplication jobApplication);
        Task DeleteJobApplicationAsync(int applicationId);
    }
}