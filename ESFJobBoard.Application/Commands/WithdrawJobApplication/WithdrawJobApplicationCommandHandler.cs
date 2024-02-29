using ESFJobBoard.Core.Exceptions;
using ESFJobBoard.Core.Repository;
using MediatR;

namespace ESFJobBoard.Application.Commands.WithdrawJobApplication
{
    public class WithdrawJobApplicationCommandHandler : IRequestHandler<WithdrawJobApplicationCommand, Unit>
    {
        private readonly IJobApplicationRepository _jobApplicationRepository;

        public WithdrawJobApplicationCommandHandler(IJobApplicationRepository jobApplicationRepository)
        {
            _jobApplicationRepository = jobApplicationRepository;
        }

        public async Task<Unit> Handle(WithdrawJobApplicationCommand request, CancellationToken cancellationToken)
        {
            var existingApplication = await _jobApplicationRepository.GetJobApplicationAsync(request.ApplicationId);

            if (existingApplication == null)
            {
                throw new NotFoundException($"Job Application with ID {request.ApplicationId} not found");
            }

            await _jobApplicationRepository.DeleteJobApplicationAsync(request.ApplicationId);

            return Unit.Value;
        }
    }
}