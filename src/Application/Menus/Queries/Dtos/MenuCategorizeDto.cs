using System.Collections.Generic;
using AutoMapper;
using DrumSpace.Application.Common.Mappings;
using DrumSpace.Domain.Entities;

namespace DrumSpace.Application.Menus.Queries.Dtos
{
    public class MenuCategorizeDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }

        public string Path { get; set; }
        public int ParentId { get; set; }

        public List<MenuCategorizeDto> AltMenus { get; set; }
    }
}