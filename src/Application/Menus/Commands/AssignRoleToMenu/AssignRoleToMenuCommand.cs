using System.Collections.Generic;
using DrumSpace.Application.Common.Models.Response;
using MediatR;

namespace DrumSpace.Application.Menus.Commands.AssignRoleToMenu
{
    public class AssignRoleToMenuCommand : IRequest<SingleResponse<bool>>
    {
        public int MenuId { get; set; }
        public List<string> Roles { get; set; }
    }
}