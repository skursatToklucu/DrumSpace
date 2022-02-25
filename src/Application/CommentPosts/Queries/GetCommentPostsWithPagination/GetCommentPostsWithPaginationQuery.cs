using DrumSpace.Application.CommentPosts.Queries.Dtos;
using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Common.Swagger;
using MediatR;

namespace DrumSpace.Application.CommentPosts.Queries.GetCommentPostsWithPagination
{
    public class GetCommentPostsWithPaginationQuery : IRequest<PagedResponse<CommentPostsDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        [SwaggerIgnoreProperty] public int PostId { get; set; }
    }
}