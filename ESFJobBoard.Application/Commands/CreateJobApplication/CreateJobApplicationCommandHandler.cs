using ESFJobBoard.Core.Entities;
using ESFJobBoard.Core.Repository;
using MediatR;

namespace ESFJobBoard.Application.Commands.CreateJobApplication
{
    public class CreateJobApplicationCommandHandler : IRequestHandler<CreateJobApplicationCommand, int>
    {
        private readonly IJobApplicationRepository _jobApplicationRepository;

        public CreateJobApplicationCommandHandler(IJobApplicationRepository jobApplicationRepository)
        {
            _jobApplicationRepository = jobApplicationRepository;
        }

        public async Task<int> Handle(CreateJobApplicationCommand request, CancellationToken cancellationToken)
        {
            var jobApplication = new JobApplication
            {
                JobId = request.JobId,
                JobSeekerId = request.JobSeekerId
            };

            await _jobApplicationRepository.AddJobApplicationAsync(jobApplication);

            return jobApplication.Id;
        }
    }
}