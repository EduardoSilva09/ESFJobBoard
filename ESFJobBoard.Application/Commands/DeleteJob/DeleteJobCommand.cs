using MediatR;

namespace ESFJobBoard.Application.Commands.DeleteJob
{
    public class DeleteJobCommand : IRequest<Unit>
    {
        public int JobId { get; set; }
    }
}