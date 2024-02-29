using MediatR;

namespace ESFJobBoard.Application.Commands.WithdrawJobApplication
{
    public class WithdrawJobApplicationCommand : IRequest<Unit>
    {
        public int ApplicationId { get; set; }
    }
}