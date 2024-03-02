using MediatR;

namespace ESFJobBoard.Application.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; private set; }
    }
}