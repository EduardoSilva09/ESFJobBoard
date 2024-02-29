using MediatR;

namespace ESFJobBoard.Application.Commands.CreateJobApplication
{
    public class CreateJobApplicationCommand : IRequest<int>
    {
        public int JobId { get; set; }
        public int JobSeekerId { get; set; }
    }
}