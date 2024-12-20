using Deerlicious.API.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Deerlicious.API.Database.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).HasMaxLength(200);
        builder.Property(e => e.Name).HasMaxLength(200);
        builder.HasMany(u => u.Users);
        builder.HasData(new Role
        {
            Id = default,
            CreatedAt = default,
            CreatedBy = default,
            UpdatedAt = default,
            UpdatedBy = default,
            IsDeleted = false,
            DeletedAt = null,
            Name = null,
            Description = null,
            Users = null
        });
    }
}