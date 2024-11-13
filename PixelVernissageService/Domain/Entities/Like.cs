using PVS.Domain.Interfaces.Entities;

namespace PVS.Domain.Entities
{
    public class Like : Entity
    {
        public long UserId { get; set; }
        public virtual required User User { get; set; }
        public long PostId { get; set; }
        public virtual required Post Post { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
