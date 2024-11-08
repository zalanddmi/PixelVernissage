namespace PVS.Domain.Interfaces.Entities
{
    public class AuditableEntity : Entity, IAuditableEntity
    {
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
