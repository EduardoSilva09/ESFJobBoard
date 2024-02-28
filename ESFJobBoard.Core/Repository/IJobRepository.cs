using ESFJobBoard.Core.Entities;

namespace ESFJobBoard.Core.Repository
{
    public interface IJobRepository
    {
        Task<Job?> GetJobByIdAsync(int jobId);
        Task<IEnumerable<Job>> GetJobsAsync();
        Task<int> AddJobAsync(Job job);
        Task UpdateJobAsync(Job job);
        Task DeleteJobAsync(int jobId);
    }
}