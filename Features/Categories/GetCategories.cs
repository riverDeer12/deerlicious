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
    bool IsDeleted);

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
        var categories = await _context.Categories.ToListAsync(cancellationToken: cancellationToken);

        if (categories.Count is 0)
        {
            await SendAsync([], cancellation: cancellationToken);
            return;
        }

        await SendAsync(categories
            .Select(x => new GetCategoryResponse(x.Id, x.Name, x.Description, x.CreatedAt, x.UpdatedAt, x.IsDeleted))
            .ToList(), cancellation: cancellationToken);
    }
}