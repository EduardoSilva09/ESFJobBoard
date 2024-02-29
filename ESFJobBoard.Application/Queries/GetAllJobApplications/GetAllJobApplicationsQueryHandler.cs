using ESFJobBoard.Core.Entities;
using ESFJobBoard.Core.Repository;
using MediatR;

namespace ESFJobBoard.Application.Queries.GetAllJobApplications
{
    public class GetAllJobApplicationsQueryHandler : IRequestHandler<GetAllJobApplicationsQuery, List<JobApplication>>
    {
        private readonly IJobApplicationRepository _jobApplicationRepository;

        public GetAllJobApplicationsQueryHandler(IJobApplicationRepository jobApplicationRepository)
        {
            _jobApplicationRepository = jobApplicationRepository;
        }

        public async Task<List<JobApplication>> Handle(GetAllJobApplicationsQuery request, CancellationToken cancellationToken)
        {
            var jobApplications = await _jobApplicationRepository.GetApplicationsAsync();
            return jobApplications.ToList();
        }
    }
}