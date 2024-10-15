using PVS.Domain.Interfaces.Entities;

namespace PVS.Domain.Entities
{
    /// <summary>
    /// Пост продажи картины
    /// </summary>
    public class Post : AuditableEntity
    {
        public required string Name { get; set; }
        public required User User { get; set; }
        public required Image Image { get; set; }
        public required string Description { get; set; } = string.Empty;
        public required string Hashtags { get; set; } = string.Empty;
        public required Genre Genre { get; set; }
        public bool IsSold { get; set; } = false;
        public bool IsArhcive { get; set; } = false;

        public List<Comment> Comments { get; set; } = [];
    }
}
