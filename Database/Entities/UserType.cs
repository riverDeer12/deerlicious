namespace Deerlicious.API.Database.Entities;

public abstract class UserType : BaseEntity
{
    public string Type { get; set; } = null!;
    
    public User User => null!;
}