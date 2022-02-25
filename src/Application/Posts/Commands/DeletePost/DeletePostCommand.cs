using DrumSpace.Application.Common.Models.Response;
using MediatR;

namespace DrumSpace.Application.Posts.Commands.DeletePost
{
    public class DeletePostCommand : IRequest<SingleResponse<bool>>
    {
        public int Id { get; set; }
    }
}