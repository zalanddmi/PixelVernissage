using PVS.Domain.Interfaces.Entities;

namespace PVS.Domain.Entities
{
    /// <summary>
    /// Комментарий
    /// </summary>
    public class Comment : AuditableEntity
    {
        public long UserId { get; set; }
        public required virtual User User { get; set; }
        public long PostId { get; set; }
        public required virtual Post Post { get; set; }
        public long? ParentId { get; set; }
        public virtual Comment? Parent { get; set; }
        public required string Text { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
