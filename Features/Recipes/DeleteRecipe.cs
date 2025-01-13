using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Recipes;

public sealed record DeleteRecipeResponse(Guid Id, string Title);

public sealed class DeleteRecipeEndpoint : EndpointWithoutRequest<DeleteRecipeResponse>
{
    private readonly DeerliciousContext _context;

    public DeleteRecipeEndpoint(DeerliciousContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Delete("api/recipes/{id}");
        Permissions(nameof(UserPermissions.CanDeleteRecipe));
        Options(x => x.WithTags("Recipes"));
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var recipeId = Route<Guid>("id", isRequired: true);

        var recipe =
            await _context.Recipes
                .FirstOrDefaultAsync(x => x.Id == recipeId, cancellationToken: cancellationToken);

        if (recipe is null)
            ThrowError(ErrorMessages.NotFound);

        recipe.Delete();

        _context.Recipes.Update(recipe);

        var result = await _context.SaveChangesAsync(cancellationToken);

        if (result is not 1)
            ThrowError(ErrorMessages.SavingError);

        await SendAsync(new DeleteRecipeResponse(recipe.Id, recipe.Title),
            cancellation: cancellationToken);
    }
}