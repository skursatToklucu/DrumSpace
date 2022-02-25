using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Users.Queries.Dtos;
using MediatR;

namespace DrumSpace.Application.Users.Queries.GetUserDetailById
{
    public class GetUserDetailByIdQuery : IRequest<SingleResponse<UserDto>>
    {
        public string Id { get; set; }
    }
}