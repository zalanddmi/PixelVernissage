using PVS.Domain.Interfaces.Entities;

namespace PVS.Domain.Entities
{
    /// <summary>
    /// Пост продажи картины
    /// </summary>
    public class Post : AuditableEntity
    {
        public required string Name { get; set; }
        public long UserId { get; set; }
        public virtual required User User { get; set; }
        public long ImageId { get; set; }
        public virtual required Image Image { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Hashtags { get; set; } = string.Empty;
        public long GenreId { get; set; }
        public virtual required Genre Genre { get; set; }
        public float Cost { get; set; } = 0;
        public bool IsSold { get; set; } = false;
        public bool IsArhcive { get; set; } = false;

        public virtual List<Comment> Comments { get; set; } = [];
    }
}
