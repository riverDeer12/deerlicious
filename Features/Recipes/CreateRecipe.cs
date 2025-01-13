using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using Deerlicious.API.Database.Entities;
using FastEndpoints;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Recipes;

public sealed record CreateRecipeRequest(string Title, string Content, List<Guid> Categories);

public sealed record CreateRecipeResponse(Guid Id, string Title);

public sealed class CreateRecipeEndpoint : Endpoint<CreateRecipeRequest, CreateRecipeResponse>
{
    private readonly DeerliciousContext _context;

    public CreateRecipeEndpoint(DeerliciousContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Post("api/recipes");
        Policies(nameof(UserPolicies.CanCreateRecipe));
        Options(x => x.WithTags("Recipes"));
    }

    public override async Task HandleAsync(CreateRecipeRequest request, CancellationToken cancellationToken)
    {
        var newRecipe = Recipe.Init(request.Title, request.Content);

        var selectedCategories = await _context.Categories
            .Where(x => request.Categories.Contains(x.Id))
            .ToListAsync(cancellationToken: cancellationToken);

        if (request.Categories.Count != selectedCategories.Count)
            ThrowError(ErrorMessages.NotFound);

        newRecipe.Categories = selectedCategories.Select(newRecipeCategory => new RecipeCategory
        {
            Recipe = newRecipe,
            Category = newRecipeCategory
        }).ToList();

        _context.Recipes.Add(newRecipe);

        var result = await _context.SaveChangesAsync(cancellationToken);

        if (result is not 1)
            ThrowError(ErrorMessages.SavingError);

        await SendAsync(new CreateRecipeResponse(newRecipe.Id, newRecipe.Title),
            cancellation: cancellationToken);
    }
}

public sealed class CreateRecipeValidator : Validator<CreateRecipeRequest>
{
    public CreateRecipeValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage(ValidationMessages.Required);
        RuleFor(x => x.Content).NotEmpty().WithMessage(ValidationMessages.Required);
        RuleFor(x => x.Categories).NotEmpty().WithMessage(ValidationMessages.Required);
    }
}