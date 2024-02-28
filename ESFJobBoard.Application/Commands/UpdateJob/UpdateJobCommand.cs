using MediatR;

namespace ESFJobBoard.Application.Commands.UpdateJob
{
    public class UpdateJobCommand : IRequest<Unit>
    {
        public int JobId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}