using ESFJobBoard.Core.Entities;
using ESFJobBoard.Core.Repository;
using MediatR;

namespace ESFJobBoard.Application.Queries.GetJobApplicationById
{
    public class GetJobApplicationByIdQueryHandler : IRequestHandler<GetJobApplicationByIdQuery, JobApplication>
    {
        private readonly IJobApplicationRepository _jobApplicationRepository;

        public GetJobApplicationByIdQueryHandler(IJobApplicationRepository jobApplicationRepository)
        {
            _jobApplicationRepository = jobApplicationRepository;
        }

        public async Task<JobApplication?> Handle(GetJobApplicationByIdQuery request, CancellationToken cancellationToken)
        {
            return await _jobApplicationRepository.GetJobApplicationAsync(request.ApplicationId);
        }
    }
}