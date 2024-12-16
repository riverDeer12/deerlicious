using System.Security.Cryptography;
using System.Text;
using Deerlicious.API.Services;

namespace Deerlicious.API.Database.Entities;

public class User : BaseEntity
{
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public bool EmailConfirmed { get; set; }
    public ICollection<UserRole> Roles { get; set; } = new List<UserRole>();

    public static User Create(string username, string password, string email)
        => new()
        {
            UserName = username,
            Email = email,
            Password = HashPassword(password),
        };
    
    public bool IsValidPassword(string password) 
        => HashPassword(password) == Password;

    private static string HashPassword(string password) =>
        BitConverter
            .ToString(
                SHA512.HashData(
                    Encoding.UTF8.GetBytes(password)))
            .Replace("-", string.Empty);
}