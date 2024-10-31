using Microsoft.EntityFrameworkCore;
using PVS.Domain.Interfaces.Entities;

namespace PVS.Domain.Entities
{
    /// <summary>
    /// Пользователь
    /// </summary>

    [Index(nameof(IdUser), IsUnique = true)]
    [Index(nameof(Username), IsUnique = true)]
    [Index(nameof(Nickname), IsUnique = true)]
    public class User : Entity
    {
        public string IdUser { get; set; }
        public string Username { get; set; }
        public string Nickname { get; set; }
        public string? FIO { get; set; }
        public string? Phonenumber { get; set; }
        public string? Email { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedAt { get; set; }
        public long? ImageId { get; set; }
        public Image? Image { get; set; }

        public List<Post> Posts { get; set; } = [];
    }
}
