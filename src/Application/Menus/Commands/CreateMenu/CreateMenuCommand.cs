using System.Collections.Generic;
using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Roles.Queries.Dtos;
using MediatR;

namespace DrumSpace.Application.Menus.Commands.CreateMenu
{
    public class CreateMenuCommand : IRequest<SingleResponse<int>>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }

        public string Path { get; set; }

        public int ParentId { get; set; }

        public List<RoleDto> Roles { get; set; }
    }
}