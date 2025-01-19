using Deerlicious.API.Database.Entities;

namespace Deerlicious.API.Services;

public interface ICategoryService
{
    bool IsCategoryUnique(string name, out Category category);
}