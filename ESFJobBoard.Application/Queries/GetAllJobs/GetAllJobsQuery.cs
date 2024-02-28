using ESFJobBoard.Core.Entities;
using MediatR;

namespace ESFJobBoard.Application.Queries.GetAllJobs
{
    public class GetAllJobsQuery : IRequest<List<Job>>
    {
    }
}