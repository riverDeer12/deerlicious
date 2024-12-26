namespace Deerlicious.API.Database.Entities;

public class Role : BaseEntity
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public ICollection<UserRole> Users { get; set; }
}