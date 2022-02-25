using DrumSpace.Domain.Common;
using DrumSpace.Domain.Enums;

namespace DrumSpace.Domain.Entities
{
    public class Rudiment : AuditableEntity
    {
        public long Id { get; set; }

        public string Pattern { get; set; }

        public int Type { get; set; }
    }
}