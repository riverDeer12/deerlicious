using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Deerlicious.API.Database.Entities;

public class User : BaseEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public Guid UserId { get; set; }
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public string Salt { get; set; } = string.Empty;
    public bool EmailConfirmed { get; set; }
    
    public ICollection<UserRole> UserRoles { get; set; } = null!;
}