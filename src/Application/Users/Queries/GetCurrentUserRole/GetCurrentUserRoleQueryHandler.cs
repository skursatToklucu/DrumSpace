using System.Threading;
using System.Threading.Tasks;
using DrumSpace.Application.Common.Interfaces;
using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Users.Queries.Dtos;
using MediatR;

namespace DrumSpace.Application.Users.Queries.GetCurrentUserRole
{
    public class
        GetCurrentUserRoleQueryHandler : IRequestHandler<GetCurrentUserRoleQuery, SingleResponse<UserWithRoleDto>>
    {
        private readonly IUserService _userService;

        public GetCurrentUserRoleQueryHandler(IUserService userService)
        {
            _userService = userService;
        }


        public async Task<SingleResponse<UserWithRoleDto>> Handle(GetCurrentUserRoleQuery request,
            CancellationToken cancellationToken)
        {
            return new SingleResponse<UserWithRoleDto>
            {
                Data = await _userService.UserRole()
            };
        }
    }
}