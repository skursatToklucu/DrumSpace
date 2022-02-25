﻿using System.Collections.Generic;
using AutoMapper;
using DrumSpace.Application.Common.Mappings;
using DrumSpace.Application.Tags.Queries.Dtos;
using DrumSpace.Domain.Entities;

namespace DrumSpace.Application.Posts.Queries.Dtos
{
    public class PostDetailDto : IMapFrom<Post>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<TagDto> Tags { get; set; }
        
        public string CreatedBy { get; set; }
        public int CommentCount { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Post, PostDetailDto>();
        }
    }
}