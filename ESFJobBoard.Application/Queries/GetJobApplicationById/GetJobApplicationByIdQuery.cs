using ESFJobBoard.Core.Entities;
using MediatR;

namespace ESFJobBoard.Application.Queries.GetJobApplicationById
{
    public class GetJobApplicationByIdQuery : IRequest<JobApplication>
    {
        public int ApplicationId { get; set; }
    }
}