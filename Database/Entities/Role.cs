using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Deerlicious.API.Database.Entities;

public class Role
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public Guid RoleId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}