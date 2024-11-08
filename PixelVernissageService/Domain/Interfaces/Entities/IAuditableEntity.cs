namespace PVS.Domain.Interfaces.Entities
{
    public interface IAuditableEntity : IEntity
    {
        string? CreatedBy { get; set; }
        string? ModifiedBy { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime? ModifiedAt { get; set; }
    }
}
