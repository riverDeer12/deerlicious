using System.ComponentModel.DataAnnotations;

namespace Deerlicious.API.Database.Entities;

public class Policy
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    
    public ICollection<RolePolicy> Roles { get; set; }
    
    public static Policy Init(string id, string name, string description, string feature)
        => new()
        {
            Id = new Guid(id),
            Name = name,
            Description = description,
            Category = feature
        };
}