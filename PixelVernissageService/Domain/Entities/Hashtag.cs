using Microsoft.EntityFrameworkCore;
using PVS.Domain.Interfaces.Entities;

namespace PVS.Domain.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class Hashtag : Entity
    {
        public required string Name { get; set; }
        public virtual List<Post> Posts { get; set; } = [];
    }
}
