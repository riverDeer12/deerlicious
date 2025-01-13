namespace Deerlicious.API.Database.Entities;

public class Recipe : BaseEntity
{
    public required string Title { get; set; }
    
    public required string Content { get; set; }
    
    public ICollection<RecipeCategory> Categories { get; set; }
    
    public static Recipe Init(string title, string content)
        => new()
        {
            Title = title,
            Content = content
        };
}