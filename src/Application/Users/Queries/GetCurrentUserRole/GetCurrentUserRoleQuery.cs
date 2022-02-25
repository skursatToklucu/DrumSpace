using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Users.Queries.Dtos;
using MediatR;

namespace DrumSpace.Application.Users.Queries.GetCurrentUserRole
{
    public class GetCurrentUserRoleQuery : IRequest<SingleResponse<UserWithRoleDto>>
    {
    }
}