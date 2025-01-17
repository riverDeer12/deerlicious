using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Categories;

public sealed record DeleteCategoryResponse(Guid Id, string Name, string Description);

public sealed class DeleteCategoryEndpoint : EndpointWithoutRequest<DeleteCategoryResponse>
{
    private readonly DeerliciousContext _context;

    public DeleteCategoryEndpoint(DeerliciousContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Delete("api/categories/{id}");
        Permissions(nameof(UserPermissions.CanDeleteCategory));
        Options(x => x.WithTags("Categories"));
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var categoryId = Route<Guid>("id", isRequired: true);

        var category =
            await _context.Categories
                .FirstOrDefaultAsync(x => x.Id == categoryId, cancellationToken: cancellationToken);

        if (category is null)
            ThrowError(ErrorMessages.NotFound);

        category.Delete();

        _context.Categories.Update(category);

        var result = await _context.SaveChangesAsync(cancellationToken);

        if (result == 0)
            ThrowError(ErrorMessages.SavingError);

        await SendAsync(new DeleteCategoryResponse(category.Id, category.Name, category.Description),
            cancellation: cancellationToken);
    }
}