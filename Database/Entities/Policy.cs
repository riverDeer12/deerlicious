namespace Deerlicious.API.Database.Entities;

public class Policy : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    
    public ICollection<RolePolicy> Roles { get; set; }
    
    public static Policy Create(string name, string description, string feature)
        => new()
        {
            Name = name,
            Description = description,
            Category = feature
        };
}