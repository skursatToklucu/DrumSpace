using System.Threading;
using System.Threading.Tasks;
using DrumSpace.Application.Common.Interfaces;
using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Roles.Queries.Dtos;
using MediatR;


namespace DrumSpace.Application.Roles.Queries.GetRoleDetailById
{
    public class GetRoleDetailByIdQueryHandler : IRequestHandler<GetRoleDetailByIdQuery, SingleResponse<RoleDto>>
    {
        private readonly IRoleService _roleService;

        public GetRoleDetailByIdQueryHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<SingleResponse<RoleDto>> Handle(GetRoleDetailByIdQuery request, CancellationToken cancellationToken)
        {
            return await _roleService.Detail(request.Id);
        }
    }
}