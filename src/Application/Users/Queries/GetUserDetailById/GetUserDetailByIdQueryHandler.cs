using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DrumSpace.Application.Common.Interfaces;
using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Users.Queries.Dtos;
using MediatR;

namespace DrumSpace.Application.Users.Queries.GetUserDetailById
{
    public class GetUserDetailByIdQueryHandler : IRequestHandler<GetUserDetailByIdQuery, SingleResponse<UserDto>>
    {
        private readonly IUserService _userService;

        public GetUserDetailByIdQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<SingleResponse<UserDto>> Handle(GetUserDetailByIdQuery request, CancellationToken cancellationToken) =>
            await _userService.Detail(request.Id);
    }
}