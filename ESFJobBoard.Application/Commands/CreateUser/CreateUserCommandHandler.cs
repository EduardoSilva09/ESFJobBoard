using ESFJobBoard.Core.Entities;
using ESFJobBoard.Core.Repository;
using MediatR;

namespace ESFJobBoard.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var newUser = new User(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Username,
                request.Password,
                request.UserType
            );

            await _userRepository.AddUserAsync(newUser);

            return newUser.Id;
        }
    }
}