namespace Domain.Interfaces.Entities
{
    public interface IAuditableEntity : IEntity
    {
        long? CreatedBy { get; set; }
        long? ModifiedBy { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime? ModifiedAt { get; set; }
    }
}
