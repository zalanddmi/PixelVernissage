using Domain.Interfaces.Entities;
using Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class PvsContext(DbContextOptions options, ICurrentUserService currentUserService) : DbContext(options)
    {
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is AuditableEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((AuditableEntity)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
                    ((AuditableEntity)entityEntry.Entity).CreatedBy = _currentUserService.CurrentUserId;
                }
                else
                {
                    Entry((AuditableEntity)entityEntry.Entity).Property(p => p.CreatedAt).IsModified = false;
                    Entry((AuditableEntity)entityEntry.Entity).Property(p => p.CreatedBy).IsModified = false;
                }
                ((AuditableEntity)entityEntry.Entity).ModifiedAt = DateTime.UtcNow;
                ((AuditableEntity)entityEntry.Entity).ModifiedBy = _currentUserService.CurrentUserId;
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
