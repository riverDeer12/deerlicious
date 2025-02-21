using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Categories;

public sealed record GetCategoryResponse(
    Guid Id,
    string Name,
    string Description,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt,
    bool IsDeleted,
    List<CategoryRecipeDto> Recipes);

public sealed record CategoryRecipeDto(
    Guid Id,
    string Title
);

public class GetCategoriesEndpoint : EndpointWithoutRequest<List<GetCategoryResponse>>
{
    private readonly DeerliciousContext _context;

    public GetCategoriesEndpoint(DeerliciousContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Get("api/categories");
        Permissions(nameof(UserPermissions.CanGetCategories));
        Options(x => x.WithTags("Categories"));
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var categories = await _context.Categories
            .Include(category => category.Recipes)
            .ThenInclude(recipeCategory => recipeCategory.Recipe)
            .ToListAsync(cancellationToken: cancellationToken);

        if (categories.Count is 0)
        {
            await SendAsync([], cancellation: cancellationToken);
            return;
        }

        var response = new List<GetCategoryResponse>();

        foreach (var category in categories)
        {
            var categoryRecipes = category.Recipes.Select(x => x.Recipe).ToList();

            var recipesResponse = categoryRecipes
                .Select(categoryRecipe =>
                    new CategoryRecipeDto(categoryRecipe.Id, categoryRecipe.Title))
                .ToList();

            var roleResponse = new GetCategoryResponse(category.Id, category.Name, category.Description,
                category.CreatedAt,
                category.UpdatedAt,
                category.IsDeleted, recipesResponse);

            response.Add(roleResponse);
        }

        await SendAsync(response, cancellation: cancellationToken);
    }
}