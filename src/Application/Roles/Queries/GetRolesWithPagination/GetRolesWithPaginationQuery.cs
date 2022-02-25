using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Roles.Queries.Dtos;
using MediatR;

namespace DrumSpace.Application.Roles.Queries.GetRolesWithPagination
{
    public class GetRolesWithPaginationQuery : IRequest<PagedResponse<RoleDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}