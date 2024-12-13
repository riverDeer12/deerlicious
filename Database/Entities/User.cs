
namespace Deerlicious.API.Database.Entities;

public class User : BaseEntity
{
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public string Salt { get; set; } = string.Empty;
    public bool EmailConfirmed { get; set; }
    public ICollection<UserRole> Roles { get; set; } = new List<UserRole>();
}