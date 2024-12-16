using System.ComponentModel.DataAnnotations.Schema;

namespace Deerlicious.API.Database.Entities;

public class Administrator : UserType
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    [NotMapped] public string FullName => $"{FirstName} {LastName}";

    public static Administrator Create(string requestFirstName, string requestLastName)
        => new ()
        {
            FirstName = requestFirstName,
            LastName = requestLastName
        };
}