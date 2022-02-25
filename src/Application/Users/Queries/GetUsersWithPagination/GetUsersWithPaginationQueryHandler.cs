using System.Threading;
using System.Threading.Tasks;
using DrumSpace.Application.Common.Interfaces;
using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Users.Queries.Dtos;
using MediatR;

namespace DrumSpace.Application.Users.Queries.GetUsersWithPagination
{
    public class GetUsersWithPaginationQueryHandler : IRequestHandler<GetUsersWithPaginationQuery, PagedResponse<UserDto>>
    {
        private readonly IUserService _userService;

        public GetUsersWithPaginationQueryHandler(IUserService userService)
            => _userService = userService;

        public async Task<PagedResponse<UserDto>> Handle(GetUsersWithPaginationQuery request, CancellationToken cancellationToken)
            => await _userService.Users(request.PageNumber, request.PageSize);
    }
}