namespace PVS.Domain.Interfaces.Entities
{
    public class AuditableEntity : Entity, IAuditableEntity
    {
        public long? CreatedBy { get; set; }
        public long? ModifiedBy { get; set; }
        public required DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
