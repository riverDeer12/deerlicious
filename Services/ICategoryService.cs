using Deerlicious.API.Database.Entities;

namespace Deerlicious.API.Services;

public interface ICategoryService
{
    Task<bool> CategoryNameExists(string name, CancellationToken cancellationToken);
}