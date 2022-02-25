using DrumSpace.Domain.Common;

namespace DrumSpace.Domain.Entities
{
    public class Menu : AuditableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }

        public string Path { get; set; }
        
        public int  ParentId { get; set; }
    }
}