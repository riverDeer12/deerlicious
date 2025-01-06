using System.Reflection;
using Deerlicious.API.Database.Entities;

namespace Deerlicious.API.Constants;

public static class UserPolicies
{
    public static readonly Policy CanGetContributors =
        Policy.Create(nameof(CanGetContributors), "Allows viewing contributors.", "Contributors");

    public static readonly Policy CanCreateContributor =
        Policy.Create(nameof(CanCreateContributor), "Allows creating new contributors.", "Contributors");

    public static readonly Policy CanUpdateContributor =
        Policy.Create(nameof(CanUpdateContributor), "Allows updating existing contributors.", "Contributors");

    public static readonly Policy CanDeleteContributor =
        Policy.Create(nameof(CanDeleteContributor), "Allows deleting contributors.", "Contributors");

    public static readonly Policy CanCreateRecipe =
        Policy.Create(nameof(CanCreateRecipe), "Allows creating recipes.", "Recipes");    
    
    public static readonly Policy CanUpdateRecipe =
        Policy.Create(nameof(CanUpdateRecipe), "Allows updating recipes.", "Recipes");
    
    public static readonly Policy CanDeleteRecipe =
        Policy.Create(nameof(CanDeleteRecipe), "Allows deleting recipes.", "Recipes");    

    public static List<Policy> GetUserPolicies()
    {
        return typeof(UserPolicies)
            .GetFields(BindingFlags.Public | BindingFlags.Static)
            .Where(field => field.FieldType == typeof(Policy))
            .Select(field => (Policy)field.GetValue(null))
            .ToList();
    }
}