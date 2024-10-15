using PVS.Domain.Interfaces.Entities;

namespace PVS.Domain.Entities
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