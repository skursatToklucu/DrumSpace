using DrumSpace.Domain.Common;

namespace DrumSpace.Domain.Entities
{
    public class MenuRole : AuditableEntity
    {
        public int Id { get; set; }
        public string RoleId { get; set; }
        public int MenuId { get; set; }
    }
}