using ESFJobBoard.Core.Entities;
using MediatR;

namespace ESFJobBoard.Application.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public int UserId { get; set; }
    }
}