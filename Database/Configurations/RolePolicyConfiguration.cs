using Deerlicious.API.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Deerlicious.API.Database.Configurations;

public class RolePolicyConfiguration : IEntityTypeConfiguration<RolePolicy>
{
    public void Configure(EntityTypeBuilder<RolePolicy> builder)
    {
        builder.HasKey(bc => new { bc.PolicyId, bc.RoleId });

        builder
            .HasOne(bc => bc.Policy)
            .WithMany(b => b.Roles)
            .HasForeignKey(bc => bc.PolicyId);

        builder
            .HasOne(bc => bc.Role)
            .WithMany(c => c.Policies)
            .HasForeignKey(bc => bc.RoleId);
    }
}