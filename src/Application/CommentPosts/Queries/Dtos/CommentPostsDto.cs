using AutoMapper;
using DrumSpace.Application.Common.Mappings;
using DrumSpace.Domain.Entities;

namespace DrumSpace.Application.CommentPosts.Queries.Dtos
{
    public class CommentPostsDto : IMapFrom<CommentPost>
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CommentPost, CommentPostsDto>();
        }
    }
}