using DrumSpace.Application.Common.Models.Response;
using MediatR;

namespace DrumSpace.Application.Tags.Commands.DeleteTag
{
    public class DeleteTagCommand : IRequest<SingleResponse<bool>>
    {
        public int Id { get; set; }
    }
}