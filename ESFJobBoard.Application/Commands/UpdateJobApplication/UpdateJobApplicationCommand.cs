using MediatR;

namespace ESFJobBoard.Application.Commands.UpdateJobApplication
{
    public class UpdateJobApplicationCommand : IRequest<Unit>
    {
        public int ApplicationId { get; set; }

    }
}