using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Recipes;

public sealed record GetRecipeResponse(Guid Id, string Title, string Content);

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
        var recipes = await _context.Recipes.ToListAsync(cancellationToken: cancellationToken);

        if (recipes.Count is 0)     {
        await SendAsync([], cancellation: cancellationToken);
        return;
    }
        
        await SendAsync(recipes
            .Select(x => new GetRecipeResponse(x.Id, x.Title, x.Content))
            .ToList(), cancellation: cancellationToken);
    }
}