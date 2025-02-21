using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Recipes;

public sealed record GetRecipeResponse(
    Guid Id,
    string Title,
    string Content,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt,
    bool IsDeleted,
    List<RecipeCategoryDto> Categories);

public sealed record RecipeCategoryDto(
    Guid Id,
    string Name);

public class GetRecipesEndpoint : EndpointWithoutRequest<List<GetRecipeResponse>>
{
    private readonly DeerliciousContext _context;

    public GetRecipesEndpoint(DeerliciousContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Get("api/recipes");
        Permissions(nameof(UserPermissions.CanGetRecipes));
        Options(x => x.WithTags("Recipes"));
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var recipes = await _context.Recipes.Include(recipe => recipe.Categories)
            .ThenInclude(recipeCategory => recipeCategory.Category)
            .ToListAsync(cancellationToken: cancellationToken);

        if (recipes.Count is 0)
        {
            await SendAsync([], cancellation: cancellationToken);
            return;
        }

        var response = new List<GetRecipeResponse>();

        foreach (var recipe in recipes)
        {
            var recipeCategories = recipe.Categories.Select(x => x.Category).ToList();

            var categoriesResponse = recipeCategories
                .Select(x => new RecipeCategoryDto(x.Id, x.Name))
                .ToList();

            var roleResponse = new GetRecipeResponse(recipe.Id, recipe.Title, recipe.Content, recipe.CreatedAt,
                recipe.UpdatedAt,
                recipe.IsDeleted, categoriesResponse);

            response.Add(roleResponse);
        }

        await SendAsync(response, cancellation: cancellationToken);
    }
}