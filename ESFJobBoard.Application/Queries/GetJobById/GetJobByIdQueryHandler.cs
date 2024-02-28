using ESFJobBoard.Core.Entities;
using ESFJobBoard.Core.Repository;
using MediatR;

namespace ESFJobBoard.Application.Queries.GetJobById
{
    public class GetJobByIdQueryHandler : IRequestHandler<GetJobByIdQuery, Job>
    {
        private readonly IJobRepository _jobRepository;

        public GetJobByIdQueryHandler(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<Job> Handle(GetJobByIdQuery request, CancellationToken cancellationToken)
        {
            var job = await _jobRepository.GetJobByIdAsync(request.JobId);
            return job;
        }
    }
}