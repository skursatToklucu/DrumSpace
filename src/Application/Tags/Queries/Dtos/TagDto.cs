using AutoMapper;
using DrumSpace.Application.Common.Mappings;
using DrumSpace.Domain.Entities;

namespace DrumSpace.Application.Tags.Queries.Dtos
{
    public class TagDto : IMapFrom<Tag>
    {
        public int Id { get; set; }
        
        public string Title { get; set; }

        public string ColourHexCode { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Tag, TagDto>();
        }
    }
}