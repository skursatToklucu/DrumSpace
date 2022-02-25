using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Menus.Queries.Dtos;
using MediatR;

namespace DrumSpace.Application.Menus.Queries.GetMenusWithPagination
{
    public class GetMenusWithPaginationQuery : IRequest<PagedResponse<MenuDto>>
    {
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;
    }
}