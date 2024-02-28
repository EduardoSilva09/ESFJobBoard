using ESFJobBoard.Core.Exceptions;
using ESFJobBoard.Core.Repository;
using MediatR;

namespace ESFJobBoard.Application.Commands.DeleteJob
{
    public class DeleteJobCommandHandler : IRequestHandler<DeleteJobCommand, Unit>
    {
        private readonly IJobRepository _jobRepository;

        public DeleteJobCommandHandler(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<Unit> Handle(DeleteJobCommand request, CancellationToken cancellationToken)
        {
            var existingJob = await _jobRepository.GetJobByIdAsync(request.JobId);

            if (existingJob == null)
            {
                throw new NotFoundException($"Job with ID {request.JobId} not found");
            }

            await _jobRepository.DeleteJobAsync(request.JobId);

            return Unit.Value;
        }
    }
}