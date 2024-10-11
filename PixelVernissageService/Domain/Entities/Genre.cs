using Domain.Interfaces.Entities;

namespace Domain.Entities
{
    /// <summary>
    /// Жанр
    /// </summary>
    public class Genre : Entity
    {
        public required string Name { get; set; }
    }
}
