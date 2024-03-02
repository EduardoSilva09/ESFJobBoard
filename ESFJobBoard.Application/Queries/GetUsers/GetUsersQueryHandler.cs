using ESFJobBoard.Core.Entities;
using ESFJobBoard.Core.Repository;
using MediatR;

namespace ESFJobBoard.Application.Queries.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            //TODO: remove the password field
            var users = await _userRepository.GetAllUsersAsync();
            return users.ToList();
        }
    }
}