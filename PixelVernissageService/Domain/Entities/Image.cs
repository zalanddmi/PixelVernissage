using Domain.Interfaces.Entities;

namespace Domain.Entities
{
    /// <summary>
    /// Изображение
    /// </summary>
    public class Image : AuditableEntity
    {
        public required string Name { get; set; }
        public required string Path { get; set; }
    }
}