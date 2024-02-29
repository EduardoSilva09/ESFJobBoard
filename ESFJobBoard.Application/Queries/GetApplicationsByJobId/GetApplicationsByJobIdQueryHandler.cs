using ESFJobBoard.Core.Entities;
using ESFJobBoard.Core.Repository;
using MediatR;

namespace ESFJobBoard.Application.Queries.GetApplicationsByJobId
{
    public class GetApplicationsByJobIdQueryHandler : IRequestHandler<GetApplicationsByJobIdQuery, List<JobApplication>>
    {
        private readonly IJobApplicationRepository _jobApplicationRepository;

        public GetApplicationsByJobIdQueryHandler(IJobApplicationRepository jobApplicationRepository)
        {
            _jobApplicationRepository = jobApplicationRepository;
        }

        public async Task<List<JobApplication>> Handle(GetApplicationsByJobIdQuery request, CancellationToken cancellationToken)
        {
            var applications = await _jobApplicationRepository.GetApplicationsByJobIdAsync(request.JobId);
            return applications.ToList();
        }
    }
}