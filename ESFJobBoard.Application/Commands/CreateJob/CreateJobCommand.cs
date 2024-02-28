using ESFJobBoard.Core.Entities;
using MediatR;

namespace ESFJobBoard.Application.Commands.CreateJob
{
    public class CreateJobCommand : IRequest<int>
    {
        public Job Job { get; set; }
    }
}