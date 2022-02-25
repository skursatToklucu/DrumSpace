using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Menus.Queries.Dtos;
using DrumSpace.Application.Posts.Queries.Dtos;
using MediatR;

namespace DrumSpace.Application.Posts.Queries.GetPostsWithPagination
{
    public class GetPostsWithPaginationQuery : IRequest<PagedResponse<PostDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}