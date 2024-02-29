using ESFJobBoard.Core.Entities;
using ESFJobBoard.Core.Repository;
using MediatR;

namespace ESFJobBoard.Application.Queries.GetApplicationsByJobSeekerId
{
    public class GetApplicationsByJobSeekerIdQueryHandler : IRequestHandler<GetApplicationsByJobSeekerIdQuery, List<JobApplication>>
    {
        private readonly IJobApplicationRepository _jobApplicationRepository;

        public GetApplicationsByJobSeekerIdQueryHandler(IJobApplicationRepository jobApplicationRepository)
        {
            _jobApplicationRepository = jobApplicationRepository;
        }

        public async Task<List<JobApplication>> Handle(GetApplicationsByJobSeekerIdQuery request, CancellationToken cancellationToken)
        {
            var applications = await _jobApplicationRepository.GetApplicationsByJobSeekerIdAsync(request.JobSeekerId);
            return applications.ToList(); // or any other processing logic you need
        }
    }
}