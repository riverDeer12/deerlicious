using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using Deerlicious.API.Database.Entities;
using Deerlicious.API.Services;
using FastEndpoints;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Categories;

public sealed record CreateCategoryRequest(string Name, string Description);

public sealed record CreateCategoryResponse(Guid Id, string Name, string Description);

public sealed class CreateCategoryEndpoint : Endpoint<CreateCategoryRequest, CreateCategoryResponse>
{
    private readonly DeerliciousContext _context;

    private readonly ICategoryService _categoryService;

    public CreateCategoryEndpoint(DeerliciousContext context, ICategoryService categoryService)
    {
        _context = context;
        _categoryService = categoryService;
    }

    public override void Configure()
    {
        Post("api/categories");
        Permissions(nameof(UserPermissions.CanCreateCategory));
        Options(x => x.WithTags("Categories"));
    }

    public override async Task HandleAsync(CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        var isCategoryUnique = _categoryService.IsCategoryUnique(request.Name, out var similarCategory);

        if (!isCategoryUnique)
        {
            await SendAsync(new CreateCategoryResponse(similarCategory.Id, similarCategory.Name, 
                    similarCategory.Description),
                cancellation: cancellationToken);
            return;
        }

        var newCategory = Category.Init(request.Name, request.Description);

        _context.Categories.Add(newCategory);

        var result = await _context.SaveChangesAsync(cancellationToken);

        if (result == 0)
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