using ESFJobBoard.Core.Entities;
using MediatR;

namespace ESFJobBoard.Application.Queries.GetJobById
{
    public class GetJobByIdQuery : IRequest<Job>
    {
        public int JobId { get; set; }
    }
}