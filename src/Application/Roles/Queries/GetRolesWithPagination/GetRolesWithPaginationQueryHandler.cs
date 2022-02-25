using System.Threading;
using System.Threading.Tasks;
using DrumSpace.Application.Common.Interfaces;
using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Roles.Queries.Dtos;
using MediatR;

namespace DrumSpace.Application.Roles.Queries.GetRolesWithPagination
{
    public class GetRolesWithPaginationQueryHandler : IRequestHandler<GetRolesWithPaginationQuery, PagedResponse<RoleDto>>
    {
        private readonly IRoleService _roleService;

        public GetRolesWithPaginationQueryHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<PagedResponse<RoleDto>> Handle(GetRolesWithPaginationQuery request, CancellationToken cancellationToken)
            => await _roleService.Roles(request.PageNumber, request.PageSize);
    }
}