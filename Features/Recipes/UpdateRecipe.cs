using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using FastEndpoints;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Recipes;

public sealed record UpdateRecipeRequest(string Title, string Content);

public sealed record UpdateRecipeResponse(Guid Id, string Title);

public sealed class UpdateRecipeEndpoint : Endpoint<UpdateRecipeRequest, UpdateRecipeResponse>
{
    private readonly DeerliciousContext _context;

    public UpdateRecipeEndpoint(DeerliciousContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Put("api/recipes/{id}");
        Roles(nameof(UserPermissions.CanUpdateRecipe));
        Options(x => x.WithTags("Recipes"));
    }

    public override async Task HandleAsync(UpdateRecipeRequest request, CancellationToken cancellationToken)
    {
        var recipeId = Route<Guid>("id", isRequired: true);

        var recipe =
            await _context.Recipes
                .FirstOrDefaultAsync(x => x.Id == recipeId, cancellationToken: cancellationToken);

        if (recipe is null)
            ThrowError(ErrorMessages.NotFound);

        recipe.Title = request.Title;
        recipe.Content = request.Content;

        _context.Recipes.Update(recipe);

        var result = await _context.SaveChangesAsync(cancellationToken);

        if (result is not 1)
            ThrowError(ErrorMessages.SavingError);

        await SendAsync(new UpdateRecipeResponse(recipe.Id, recipe.Title), cancellation: cancellationToken);
    }
}

public sealed class UpdateRecipeValidator : Validator<UpdateRecipeRequest>
{
    public UpdateRecipeValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage(ValidationMessages.Required);
        RuleFor(x => x.Content).NotEmpty().WithMessage(ValidationMessages.Required);
    }
}