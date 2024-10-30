using PVS.Domain.Interfaces.Entities;

namespace PVS.Domain.Entities
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User : Entity
    {
        public required string IdUser { get; set; }
        public required string Username { get; set; }
        public required string Nickname { get; set; }
        public string? FIO { get; set; }
        public string? Phonenumber { get; set; }
        public string? Email { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? ModifiedAt { get; set; }
        public long? ImageId { get; set; }
        public Image? Image { get; set; }

        public List<Post> Posts { get; set; } = [];
    }
}
