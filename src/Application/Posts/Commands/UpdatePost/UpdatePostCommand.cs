using DrumSpace.Application.Common.Models.Response;
using MediatR;

namespace DrumSpace.Application.Posts.Commands.UpdatePost
{
    public class UpdatePostCommand : IRequest<SingleResponse<bool>>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}