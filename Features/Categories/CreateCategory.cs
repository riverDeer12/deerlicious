using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using Deerlicious.API.Database.Entities;
using FastEndpoints;
using FluentValidation;

namespace Deerlicious.API.Features.Categories;

public sealed record CreateCategoryRequest(string Name, string Description);

public sealed record CreateCategoryResponse(Guid Id, string Name, string Description);

public sealed class CreateCategoryEndpoint : Endpoint<CreateCategoryRequest, CreateCategoryResponse>
{
    private readonly DeerliciousContext _context;

    public CreateCategoryEndpoint(DeerliciousContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Post("api/categories");
        Permissions(nameof(UserPermissions.CanCreateCategory));
        Options(x => x.WithTags("Categories"));
    }

    public override async Task HandleAsync(CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        var newCategory = Category.Init(request.Name, request.Description);

        _context.Categories.Add(newCategory);

        var result = await _context.SaveChangesAsync(cancellationToken);

        if (result is not 1)
            ThrowError(ErrorMessages.SavingError);

        await SendAsync(new CreateCategoryResponse(newCategory.Id, newCategory.Name, newCategory.Description),
            cancellation: cancellationToken);
    }
}

public sealed class CreateCategoryValidator : Validator<CreateCategoryRequest>
{
    public CreateCategoryValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage(ValidationMessages.Required);
        RuleFor(x => x.Description).NotEmpty().WithMessage(ValidationMessages.Required);
    }
}