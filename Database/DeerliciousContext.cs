using Deerlicious.API.Database.Configurations;
using Deerlicious.API.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Database;

public class DeerliciousContext(DbContextOptions<DeerliciousContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RoleConfiguration).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}