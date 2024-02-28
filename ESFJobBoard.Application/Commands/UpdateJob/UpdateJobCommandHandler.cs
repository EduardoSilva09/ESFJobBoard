using ESFJobBoard.Core.Exceptions;
using ESFJobBoard.Core.Repository;
using MediatR;

namespace ESFJobBoard.Application.Commands.UpdateJob
{
    public class UpdateJobCommandHandler : IRequestHandler<UpdateJobCommand, Unit>
    {
        private readonly IJobRepository _jobRepository;

        public UpdateJobCommandHandler(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<Unit> Handle(UpdateJobCommand request, CancellationToken cancellationToken)
        {
            var existingJob = await _jobRepository.GetJobByIdAsync(request.JobId);

            if (existingJob == null)
            {
                // Throw a NotFoundException
                throw new NotFoundException($"Job with ID {request.JobId} not found");
            }

            // Update the properties with non-null values
            existingJob.Title = request.Title ?? existingJob.Title;
            existingJob.Description = request.Description ?? existingJob.Description;

            await _jobRepository.UpdateJobAsync(existingJob);

            return Unit.Value;
        }
    }
}