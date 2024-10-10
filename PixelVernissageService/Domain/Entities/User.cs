using Domain.Interfaces.Entities;

namespace Domain.Entities
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
        public Image? Image { get; set; }

        public List<Image> Images { get; set; } = [];
    }
}
