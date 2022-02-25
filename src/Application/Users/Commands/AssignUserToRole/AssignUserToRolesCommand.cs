using System.Collections.Generic;
using DrumSpace.Application.Common.Models.Response;
using MediatR;

namespace DrumSpace.Application.Users.Commands.AssignUserToRole
{
    public class AssignUserToRolesCommand : IRequest<SingleResponse<bool>>
    {
        public string UserId { get; set; }
        public List<string> RoleIds { get; set; }
    }
}