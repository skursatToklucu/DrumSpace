using DrumSpace.Domain.Common;
// ReSharper disable All

namespace DrumSpace.Domain.Entities
{
    public class CommentPost : AuditableEntity
    {
        public int Id { get; set; }
        // ReSharper disable once PropertyCanBeMadeInitOnly.Global
        public string Description { get; set; }

        public int PostId { get; set; }
        
        public Post Post { get; set; }
    }
}