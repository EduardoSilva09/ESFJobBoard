using ESFJobBoard.Core.Exceptions;
using ESFJobBoard.Core.Repository;
using MediatR;

namespace ESFJobBoard.Application.Commands.UpdateJobApplication
{
    public class UpdateJobApplicationCommandHandler : IRequestHandler<UpdateJobApplicationCommand, Unit>
    {
        private readonly IJobApplicationRepository _jobApplicationRepository;

        public UpdateJobApplicationCommandHandler(IJobApplicationRepository jobApplicationRepository)
        {
            _jobApplicationRepository = jobApplicationRepository;
        }

        public async Task<Unit> Handle(UpdateJobApplicationCommand request, CancellationToken cancellationToken)
        {
            var existingApplication = await _jobApplicationRepository.GetJobApplicationAsync(request.ApplicationId);

            if (existingApplication == null)
            {
                throw new NotFoundException($"Job Application with ID {request.ApplicationId} not found");
            }

            await _jobApplicationRepository.UpdateJobApplicationAsync(existingApplication);
            return Unit.Value;
        }
    }
}