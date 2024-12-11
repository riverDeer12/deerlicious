namespace Deerlicious.API.Services;

public interface IPasswordService
{
    bool CompareHashes(string requestPassword, string password);
    string HashPasswordWithSalt(string password, string salt);
    string GenerateSalt();
}