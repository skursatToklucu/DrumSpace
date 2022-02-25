using DrumSpace.Application.Common.Models.Response;
using MediatR;

namespace DrumSpace.Application.Roles.Commands.DeleteRole
{
    public class DeleteRoleCommand : IRequest<SingleResponse<bool>>
    {
        public string RoleId { get; set; }
    }
}