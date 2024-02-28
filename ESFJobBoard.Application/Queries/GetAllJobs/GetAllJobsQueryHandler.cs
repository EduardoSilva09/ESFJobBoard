using ESFJobBoard.Core.Entities;
using ESFJobBoard.Core.Repository;

namespace ESFJobBoard.Application.Queries.GetAllJobs
{
    public class GetAllJobsQueryHandler
    {
        private readonly IJobRepository _jobRepository;

        public GetAllJobsQueryHandler(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<List<Job>> Handle(GetAllJobsQuery request, CancellationToken cancellationToken)
        {
            // Retrieve the list of jobs from the repository
            var jobs = await _jobRepository.GetJobsAsync();

            return jobs.ToList();
        }
    }
}