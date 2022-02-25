using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Tags.Queries.Dtos;
using MediatR;

namespace DrumSpace.Application.Tags.Queries.GetTagsWithPagination
{
    public class GetTagsWithPaginationQuery : IRequest<PagedResponse<TagDto>>
    { 
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}