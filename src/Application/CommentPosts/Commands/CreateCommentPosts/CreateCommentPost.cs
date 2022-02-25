using DrumSpace.Application.Common.Models.Response;
using MediatR;

namespace DrumSpace.Application.CommentPosts.Commands.CreateCommentPosts
{
    public class CreateCommentPost : IRequest<SingleResponse<bool>>
    {
        public string Description { get; set; }
        public int PostId { get; set; }
    }
}