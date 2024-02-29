using ESFJobBoard.Core.Entities;
using MediatR;

namespace ESFJobBoard.Application.Queries.GetApplicationsByJobId
{
    public class GetApplicationsByJobIdQuery : IRequest<List<JobApplication>>
    {
        public int JobId { get; set; }
    }
}