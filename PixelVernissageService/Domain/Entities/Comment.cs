using PVS.Domain.Interfaces.Entities;

namespace PVS.Domain.Entities
{
    /// <summary>
    /// Комментарий
    /// </summary>
    public class Comment : AuditableEntity
    {
        public required User User { get; set; }
        public required Post Post { get; set; }
        public Comment? Parent { get; set; }
        public required string Text { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
