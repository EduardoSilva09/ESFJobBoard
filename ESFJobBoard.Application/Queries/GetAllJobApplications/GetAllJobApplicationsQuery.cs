using ESFJobBoard.Core.Entities;
using MediatR;

namespace ESFJobBoard.Application.Queries.GetAllJobApplications
{
    public class GetAllJobApplicationsQuery : IRequest<List<JobApplication>>
    {
    }
}