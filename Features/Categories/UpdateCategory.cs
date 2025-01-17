using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using Deerlicious.API.Features.Roles;
using FastEndpoints;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Categories;

public sealed record UpdateCategoryRequest(string Name, string Description);

public sealed record UpdateCategoryResponse(Guid Id, string Name, string Description);

public sealed class UpdateCategoryEndpoint : Endpoint<UpdateCategoryRequest, UpdateCategoryResponse>
{
    private readonly DeerliciousContext _context;

    public UpdateCategoryEndpoint(DeerliciousContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Put("api/categories/{id}");
        Permissions(nameof(UserPermissions.CanUpdateCategory));
        Options(x => x.WithTags("Categories"));
    }

    public override async Task HandleAsync(UpdateCategoryRequest request, CancellationToken cancellationToken)
    {
        var categoryId = Route<Guid>("id", isRequired: true);

        var category =
            await _context.Categories
                .FirstOrDefaultAsync(x => x.Id == categoryId, cancellationToken: cancellationToken);

        if (category is null)
            ThrowError(ErrorMessages.NotFound);

        category.Name = request.Name;
        category.Description = request.Description;

        _context.Categories.Update(category);

        var result = await _context.SaveChangesAsync(cancellationToken);

        if (result == 0)
            ThrowError(ErrorMessages.SavingError);

        await SendAsync(new UpdateCategoryResponse(category.Id, category.Name, category.Description),
            cancellation: cancellationToken);
    }
}

public sealed class UpdateCategoryValidator : Validator<UpdateCategoryRequest>
{
    public UpdateCategoryValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage(ValidationMessages.Required);
        RuleFor(x => x.Description).NotEmpty().WithMessage(ValidationMessages.Required);
    }
}