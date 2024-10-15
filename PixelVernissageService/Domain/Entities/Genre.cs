using PVS.Domain.Interfaces.Entities;

namespace PVS.Domain.Entities
{
    /// <summary>
    /// Жанр
    /// </summary>
    public class Genre : Entity
    {
        public required string Name { get; set; }
    }
}
