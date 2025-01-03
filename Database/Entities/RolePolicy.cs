namespace Deerlicious.API.Database.Entities;

public class RolePolicy
{
    public Guid RoleId { get; set; }
    
    public Role Role { get; set; }
    
    public Guid PolicyId { get; set; }
    
    public Policy Policy { get; set; }

}