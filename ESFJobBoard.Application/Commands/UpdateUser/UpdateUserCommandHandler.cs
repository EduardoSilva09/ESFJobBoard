using ESFJobBoard.Core.Exceptions;
using ESFJobBoard.Core.Repository;
using MediatR;

namespace ESFJobBoard.Application.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetUserByIdAsync(request.UserId);

            if (existingUser == null)
            {
                throw new NotFoundException($"User with ID {request.UserId} not found");
            }
            // Update the user properties with non-null values
            existingUser.FirstName = request.FirstName ?? existingUser.FirstName;
            existingUser.LastName = request.LastName ?? existingUser.LastName;
            existingUser.Email = request.Email ?? existingUser.Email;

            await _userRepository.UpdateUserAsync(existingUser);

            return Unit.Value;
        }
    }
}