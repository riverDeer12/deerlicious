using Deerlicious.API.Constants;
using Deerlicious.API.Database.Entities;
using Deerlicious.API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Deerlicious.API.Database.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    private readonly IPasswordService _passwordService;

    public UserConfiguration(IPasswordService passwordService)
    {
        _passwordService = passwordService;
    }

    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => e.UserId);
        builder.Property(e => e.UserName).HasMaxLength(200);
        builder.Property(e => e.Email).HasMaxLength(200);
        builder.Property(e => e.Password).HasMaxLength(200);
        builder.HasMany(u => u.UserRoles);

        var salt = _passwordService.GenerateSalt();

        builder.HasData(new User
        {
            Email = SeedData.SuperAdminEmail,
            UserName = SeedData.SuperAdminUserName,
            Salt = salt,
            Password = _passwordService
                .HashPasswordWithSalt(SeedData.SuperAdminPassword, salt),
            EmailConfirmed = true
        });
    }
}