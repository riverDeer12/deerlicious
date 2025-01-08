using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using Deerlicious.API.Database.Entities;
using FastEndpoints;
using FluentValidation;

namespace Deerlicious.API.Features.Recipes;

public sealed record CreateRecipeRequest(string Title, string Content);
public sealed record CreateRecipeResponse(Guid Id, string Title);

public sealed class CreateRecipeEndpoint(DeerliciousContext context)
    : Endpoint<CreateRecipeRequest, CreateRecipeResponse>
{
    public override void Configure()
    {
        Post("api/recipes");
        Policies(nameof(UserPolicies.CanCreateRecipe));
        Options(x => x.WithTags("Recipes"));
    }
    
    public override async Task HandleAsync(CreateRecipeRequest request, CancellationToken cancellationToken)
    {
        var newRecipe = Recipe.Create(request.Title, request.Content);

        context.Recipes.Add(newRecipe);
        
        var result = await context.SaveChangesAsync(cancellationToken);

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
    }
}