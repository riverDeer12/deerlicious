using System.Reflection;
using Deerlicious.API.Database.Entities;

namespace Deerlicious.API.Constants;

public static class UserPolicies
{
    public static readonly Policy CanGetContributors =
        Policy.Create("CanGetContributors", "Allows viewing contributors.", "Contributors");

    public static readonly Policy CanCreateContributor =
        Policy.Create("CanCreateContributor", "Allows creating new contributors.", "Contributors");

    public static readonly Policy CanUpdateContributor =
        Policy.Create("CanUpdateContributor", "Allows updating existing contributors.", "Contributors");

    public static readonly Policy CanDeleteContributor =
        Policy.Create("CanDeleteContributor", "Allows deleting contributors.", "Contributors");

    public static List<Policy> GetUserPolicies()
    {
        return typeof(UserPolicies)
            .GetFields(BindingFlags.Public | BindingFlags.Static)
            .Where(field => field.FieldType == typeof(Policy))
            .Select(field => (Policy)field.GetValue(null))
            .ToList();
    }
}