using ESFJobBoard.Core.Exceptions;
using ESFJobBoard.Core.Repository;
using MediatR;

namespace ESFJobBoard.Application.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetUserByIdAsync(request.UserId);

            if (existingUser == null)
            {
                throw new NotFoundException($"User with ID {request.UserId} not found");
            }

            await _userRepository.DeleteUserAsync(existingUser);

            return Unit.Value;
        }
    }
}