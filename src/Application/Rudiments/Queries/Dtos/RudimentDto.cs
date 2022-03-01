using AutoMapper;
using DrumSpace.Application.Common.Mappings;
using DrumSpace.Domain.Entities;

namespace DrumSpace.Application.Rudiments.Queries.Dtos
{
    public class RudimentDto : IMapFrom<Rudiment>
    {
        public long Id { get; set; }
        public string Pattern { get; set; }
        public int Type { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Rudiment, RudimentDto>();
        }
    }
}