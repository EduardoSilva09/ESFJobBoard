using ESFJobBoard.Core.Entities;
using MediatR;

namespace ESFJobBoard.Application.Queries.GetUsers
{
    public class GetUsersQuery : IRequest<List<User>>
    {

    }
}