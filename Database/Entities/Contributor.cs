using System.ComponentModel.DataAnnotations.Schema;

namespace Deerlicious.API.Database.Entities;

public class Contributor : UserType
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    [NotMapped] public string FullName => $"{FirstName} {LastName}";
    
    public static Contributor Create(string requestFirstName, string requestLastName)
        => new ()
        {
            FirstName = requestFirstName,
            LastName = requestLastName
        };
}