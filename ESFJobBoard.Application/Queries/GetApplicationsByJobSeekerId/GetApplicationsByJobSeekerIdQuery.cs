using ESFJobBoard.Core.Entities;
using MediatR;

namespace ESFJobBoard.Application.Queries.GetApplicationsByJobSeekerId
{
    public class GetApplicationsByJobSeekerIdQuery : IRequest<List<JobApplication>>
    {
        public int JobSeekerId { get; set; }
    }
}