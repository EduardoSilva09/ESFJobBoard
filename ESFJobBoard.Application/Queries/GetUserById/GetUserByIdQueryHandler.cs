using ESFJobBoard.Core.Entities;
using ESFJobBoard.Core.Exceptions;
using ESFJobBoard.Core.Repository;
using MediatR;

namespace ESFJobBoard.Application.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.UserId);

            if (user == null)
            {
                throw new NotFoundException($"User with ID {request.UserId} not found");
            }

            return user;
        }
    }
}