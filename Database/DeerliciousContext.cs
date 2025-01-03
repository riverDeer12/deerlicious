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
    
    public DbSet<Policy> Policies { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<RolePolicy> RolePolicies { get; set; }
    public DbSet<User> Users { get; set; }
    
    public DbSet<UserRole> UserRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AdministratorConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PolicyConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RoleConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RolePolicyConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserRoleConfiguration).Assembly);

        // Seed Users
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = new Guid(SeedData.SuperAdminId),
                CreatedAt = DateTimeOffset.Now,
                CreatedBy = new Guid(SeedData.SuperAdminId),
                UpdatedAt = DateTimeOffset.Now,
                UpdatedBy = new Guid(SeedData.SuperAdminId),
                IsDeleted = false,
                DeletedAt = null,
                UserName = SeedData.SuperAdminUserName,
                Email = SeedData.SuperAdminEmail,
                Password = User.HashPassword(SeedData.SuperAdminPassword),
                EmailConfirmed = true
            });

        // Seed Roles
        modelBuilder.Entity<Role>().HasData(
            new Role
            {
                Id = new Guid(SeedData.SuperAdminRoleId),
                CreatedAt = DateTimeOffset.Now,
                CreatedBy = new Guid(SeedData.SuperAdminId),
                UpdatedAt = DateTimeOffset.Now,
                UpdatedBy = new Guid(SeedData.SuperAdminId),
                IsDeleted = false,
                DeletedAt = null,
                Name = SeedData.SuperAdminRoleName,
                Description = SeedData.SuperAdminRoleDescription,
            });

        // Seed UserRole (pivot table)
        modelBuilder.Entity<UserRole>().HasData(
            new UserRole
            {
                UserId = new Guid(SeedData.SuperAdminId),
                RoleId = new Guid(SeedData.SuperAdminRoleId)
            }
        );

        // Seed Administrator
        modelBuilder.Entity<Administrator>().HasData(new Administrator
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateTimeOffset.Now,
            CreatedBy = new Guid(SeedData.SuperAdminId),
            UpdatedAt = DateTimeOffset.Now,
            UpdatedBy = new Guid(SeedData.SuperAdminId),
            IsDeleted = false,
            DeletedAt = null,
            UserId = new Guid(SeedData.SuperAdminId),
            FirstName = SeedData.SuperAdminFirstName,
            LastName = SeedData.SuperAdminLastName
        });
        
        // Seed Policies
        
        var policies = UserPolicies.GetUserPolicies()
            .Select(policy => new Policy
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                CreatedBy = new Guid(SeedData.SuperAdminId),
                UpdatedAt = DateTimeOffset.Now,
                UpdatedBy = new Guid(SeedData.SuperAdminId),
                IsDeleted = false,
                DeletedAt = null,
                Name = policy.Name,
                Description = policy.Description,
                Category = policy.Category 
            })
            .ToList();        
        
        modelBuilder.Entity<Policy>().HasData(policies);

        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e is
            {
                Entity: BaseEntity, State: EntityState.Added or
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
                case EntityState.Detached:
                case EntityState.Unchanged:
                case EntityState.Modified:
                case EntityState.Deleted:
                    break;
                default:
                    throw new Exception(ErrorMessages.SavingError);
            }

            entity.UpdatedAt = DateTimeOffset.Now;
            entity.UpdatedBy = _currentUserService.UserId;
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}