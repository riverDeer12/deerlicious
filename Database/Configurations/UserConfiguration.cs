using Deerlicious.API.Constants;
using Deerlicious.API.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Deerlicious.API.Database.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.UserName).HasMaxLength(200);
        builder.Property(e => e.Email).HasMaxLength(200);
        builder.Property(e => e.Password).HasMaxLength(200);
        
        builder.HasMany(u => u.Roles);

        builder
            .HasOne(a => a.Administrator)
            .WithOne(b => b.User)
            .HasForeignKey<Administrator>(b => b.UserId);
        
        builder
            .HasOne(a => a.Contributor)
            .WithOne(b => b.User)
            .HasForeignKey<Contributor>(b => b.UserId);
        
        builder.ToTable("Users", c => c.IsTemporal());
    }
    
}