using Microsoft.EntityFrameworkCore;
using PVS.Domain.Entities;
using PVS.Domain.Interfaces.Entities;
using PVS.Domain.Interfaces.Services;

namespace PVS.Infrastructure.Context
{
    public class PvsContext(DbContextOptions options, ICurrentUserService currentUserService) : DbContext(options)
    {
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new Genre() { Id = 1, Name = "Портрет" },
                new Genre() { Id = 2, Name = "Пейзаж" },
                new Genre() { Id = 3, Name = "Натюрморт" },
                new Genre() { Id = 4, Name = "Архитектура" }
            );
        }

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
