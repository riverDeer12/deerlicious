using Deerlicious.API.Database;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Services;

public class CategoryService : ICategoryService
{
    private readonly DeerliciousContext _context;

    public CategoryService(DeerliciousContext context)
    {
        _context = context;
    }

    public async Task<bool> CategoryNameExists(string name, CancellationToken cancellationToken)
    {
        return await _context.Categories
            .AnyAsync(x => x.Name == name, cancellationToken);
    }
}