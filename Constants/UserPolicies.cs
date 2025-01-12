using System.Reflection;
using Deerlicious.API.Database.Entities;

namespace Deerlicious.API.Constants;

public static class UserPolicies
{
    public static readonly Policy CanGetContributors =
        Policy.Create("c9b1e9a7-8bb0-4c29-86db-cbb4389e6393", nameof(CanGetContributors),
            "Allows viewing contributors.", "Contributors");

    public static readonly Policy CanCreateContributor =
        Policy.Create("4b60b7a5-53c3-4b43-9793-b0354a29dca1", nameof(CanCreateContributor),
            "Allows creating new contributors.", "Contributors");

    public static readonly Policy CanUpdateContributor =
        Policy.Create("2f54d3f8-4f36-45f9-914d-12231b9c7a77", nameof(CanUpdateContributor),
            "Allows updating existing contributors.", "Contributors");

    public static readonly Policy CanDeleteContributor =
        Policy.Create("1b5a4f8f-4478-4e66-b636-4b7f5c3cdb28", nameof(CanDeleteContributor),
            "Allows deleting contributors.", "Contributors");

    public static readonly Policy CanGetRecipes =
        Policy.Create("6bfa4f27-39cd-4a23-9a90-503b7562de09", nameof(CanGetRecipes), "Allows viewing recipes.",
            "Recipes");

    public static readonly Policy CanCreateRecipe =
        Policy.Create("74253b8e-6b5d-48f4-becb-02cc909de4bc", nameof(CanCreateRecipe), "Allows creating recipes.",
            "Recipes");

    public static readonly Policy CanUpdateRecipe =
        Policy.Create("d07047e2-9c97-4f86-bb69-46699f9935b1", nameof(CanUpdateRecipe), "Allows updating recipes.",
            "Recipes");

    public static readonly Policy CanDeleteRecipe =
        Policy.Create("b23e50c8-9e16-44b3-b7d4-b4e470306f87", nameof(CanDeleteRecipe), "Allows deleting recipes.",
            "Recipes");

    public static readonly Policy CanGetCategories =
        Policy.Create("d6fbb48f-5b7b-480c-8a12-117a8b5a68fd", nameof(CanGetCategories),
            "Allows viewing recipe categories.",
            "Categories");

    public static readonly Policy CanCreateCategory =
        Policy.Create("2875f239-3d11-452e-acdd-b8bff6a50970", nameof(CanCreateCategory),
            "Allows creating recipe categories.",
            "Categories");

    public static readonly Policy CanUpdateCategory =
        Policy.Create("e8f80d47-e956-4e05-a91b-d51315e629fd", nameof(CanUpdateCategory),
            "Allows updating recipe category.",
            "Categories");

    public static readonly Policy CanDeleteCategory =
        Policy.Create("c02b2833-ded9-4e6b-af6a-74a06cb2ffe0", nameof(CanDeleteCategory),
            "Allows deleting recipe category.",
            "Categories");


    public static List<Policy> GetUserPolicies()
    {
        return typeof(UserPolicies)
            .GetFields(BindingFlags.Public | BindingFlags.Static)
            .Where(field => field.FieldType == typeof(Policy))
            .Select(field => (Policy)field.GetValue(null))
            .ToList();
    }
}