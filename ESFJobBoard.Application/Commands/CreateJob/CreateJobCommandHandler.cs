using ESFJobBoard.Core.Repository;
using MediatR;

namespace ESFJobBoard.Application.Commands.CreateJob
{
    public class CreateJobCommandHandler : IRequestHandler<CreateJobCommand, int>
    {
        private readonly IJobRepository _jobRepository;

        public CreateJobCommandHandler(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<int> Handle(CreateJobCommand request, CancellationToken cancellationToken)
        {
            var jobId = await _jobRepository.AddJobAsync(request.Job);
            return jobId;
        }
    }
}