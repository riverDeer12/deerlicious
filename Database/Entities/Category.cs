namespace Deerlicious.API.Database.Entities;

public class Category : BaseEntity
{
    public required string Name { get; set; }
    
    public required string Description { get; set; }
    
    public ICollection<RecipeCategory> Recipes { get; set; } 
    
    public static Category Create(string name, string description)
        => new()
        {
            Name = name,
            Description = description
        };
}