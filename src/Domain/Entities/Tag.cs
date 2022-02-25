using System.Collections.Generic;
using DrumSpace.Domain.Common;


namespace DrumSpace.Domain.Entities
{
    public class Tag : AuditableEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ColourHexCode { get; set; }
        public string IconPath { get; set; }
        public List<Post> Posts { get; } = new();
    }
}