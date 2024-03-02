using MediatR;

namespace ESFJobBoard.Application.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<Unit>
    {
        public int UserId { get; set; }
    }
}