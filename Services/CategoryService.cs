using Deerlicious.API.Database;
using Deerlicious.API.Database.Entities;

namespace Deerlicious.API.Services;

public class CategoryService : ICategoryService
{
    private readonly DeerliciousContext _context;

    public CategoryService(DeerliciousContext context)
    {
        _context = context;
    }

    public bool IsCategoryUnique(string name, out Category category)
    {
        var similarCategory = _context.Categories.FirstOrDefault(x => x.Name == name);

        if (similarCategory is null)
        {
            category = null!;
            
            return true;
        }

        category = similarCategory;

        return false;
    }
}