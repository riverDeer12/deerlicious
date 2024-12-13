using Deerlicious.API.Constants;
using Deerlicious.API.Database.Configurations;
using Deerlicious.API.Database.Entities;
using Deerlicious.API.Services;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Database;

public class DeerliciousContext : DbContext
{
    private readonly ICurrentUserService _currentUserService;
    
    public DeerliciousContext(DbContextOptions<DeerliciousContext> options, ICurrentUserService currentUserService)
        : base(options)
    {
        _currentUserService = currentUserService;
    }
    
    public DbSet<Administrator> Administrators { get; set; }
    public DbSet<Contributor> Contributors { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e is { Entity: BaseEntity, State: EntityState.Added or 
                EntityState.Modified or 
                EntityState.Deleted
            });

        foreach (var entry in entries)
        {
            var entity = (BaseEntity)entry.Entity;

            switch (entry.State)
            {
                case EntityState.Added:
                    entity.CreatedAt = DateTimeOffset.Now;
                    entity.CreatedBy = _currentUserService.UserId;
                    break;
                case EntityState.Deleted:
                    entity.DeletedAt = DateTimeOffset.Now;
                    entity.IsDeleted = true;
                    break;
                case EntityState.Detached:
                    break;
                case EntityState.Unchanged:
                    break;
                case EntityState.Modified:
                    break;
                default:
                    throw new Exception(ValidationMessages.SavingError);
            }

            entity.UpdatedAt = DateTimeOffset.Now;
            entity.UpdatedBy = _currentUserService.UserId;
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}