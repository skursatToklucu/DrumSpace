using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Roles.Queries.Dtos;
using MediatR;

namespace DrumSpace.Application.Roles.Queries.GetRoleDetailById
{
    public class GetRoleDetailByIdQuery : IRequest<SingleResponse<RoleDto>>
    {
        public string Id { get; set; }
    }
}