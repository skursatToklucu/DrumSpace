using System.Collections.Generic;
using DrumSpace.Domain.Common;
using DrumSpace.Domain.Enums;

namespace DrumSpace.Domain.Entities
{
    public class Post : AuditableEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
        public PostType PostType { get; set; }
        public string Description { get; set; }

        public List<Tag> Tags { get; } = new();

        public List<CommentPost> CommentPosts { get; set; }
    }
}