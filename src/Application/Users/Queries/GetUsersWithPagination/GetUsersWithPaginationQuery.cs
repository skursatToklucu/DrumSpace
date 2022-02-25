using DrumSpace.Application.Common.Models;
using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Users.Queries.Dtos;
using MediatR;

namespace DrumSpace.Application.Users.Queries.GetUsersWithPagination
{
    public class GetUsersWithPaginationQuery : IRequest<PagedResponse<UserDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}