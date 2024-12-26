using System.Security.Cryptography;
using System.Text;

namespace Deerlicious.API.Database.Entities;

public class User : BaseEntity
{
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public bool EmailConfirmed { get; set; }
    public ICollection<UserRole> Roles { get; set; }
    
    public Administrator Administrator { get; set; } = null!;

    public Contributor Contributor { get; set; } = null!;

    public static User Create(string username, string password, string email)
        => new()
        {
            UserName = username,
            Email = email,
            Password = HashPassword(password),
        };
    
    public bool IsValidPassword(string password) 
        => HashPassword(password) == Password;

    public static string HashPassword(string password) =>
        BitConverter
            .ToString(
                SHA512.HashData(
                    Encoding.UTF8.GetBytes(password)))
            .Replace("-", string.Empty);
}