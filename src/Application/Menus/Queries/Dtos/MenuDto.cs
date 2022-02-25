using AutoMapper;
using DrumSpace.Application.Common.Mappings;
using DrumSpace.Domain.Entities;

namespace DrumSpace.Application.Menus.Queries.Dtos
{
    public class MenuDto : IMapFrom<Menu>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }

        public string Path { get; set; }

        public int ParentId { get; set; }
     
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Menu, MenuDto>();
        }
    }
}