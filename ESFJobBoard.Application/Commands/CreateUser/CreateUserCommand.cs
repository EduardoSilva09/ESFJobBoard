using ESFJobBoard.Core.Enums;
using MediatR;

namespace ESFJobBoard.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserTypeEnum UserType { get; set; }
    }
}