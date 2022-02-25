using System.Collections.Generic;
using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Tags.Commands.CreateTag;
using DrumSpace.Application.Tags.Queries.Dtos;
using DrumSpace.Domain.Enums;
using MediatR;

namespace DrumSpace.Application.Posts.Commands.CreatePost
{
    public class CreatePostCommand : IRequest<SingleResponse<int>>
    {
        
        public string Title { get; set; }
        public List<CreateTagDto> Tags { get; set; }
        public PostType PostType { get; set; }
        public string Description { get; set; }
    }
}