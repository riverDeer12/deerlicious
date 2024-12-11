using System.Security.Cryptography;
using System.Text;

namespace Deerlicious.API.Services;

public class PasswordService : IPasswordService
{
    public string HashPasswordWithSalt(string password, string salt)
    {
        var passwordBytes = Encoding.UTF8.GetBytes(password);
        
        var passwordWithSaltBytes = new byte[passwordBytes.Length + salt.Length];
        
        var saltBytes = Encoding.UTF8.GetBytes(salt);

        Buffer.BlockCopy(passwordBytes, 0, passwordWithSaltBytes, 0, passwordBytes.Length);
        Buffer.BlockCopy(saltBytes, 0, passwordWithSaltBytes, passwordBytes.Length, salt.Length);

        var hashedData = SHA512.HashData(passwordWithSaltBytes);

        return Convert.ToBase64String(hashedData);
    }
    
    public bool CompareHashes(string requestPassword, string password)
    {
        var hash1 = Encoding.UTF8.GetBytes(requestPassword);
        
        var hash2 = Encoding.UTF8.GetBytes(password);
        
        // Check if the lengths are the same
        if (hash1.Length != hash2.Length)
            return false;

        // Compare byte by byte
        for (var i = 0; i < hash1.Length; i++)
        {
            if (hash1[i] != hash2[i])
                return false;
        }

        return true;
    }

    public string GenerateSalt()
    {
        const int saltLength = 32;
        
        using var rng = RandomNumberGenerator.Create();
        
        var salt = new byte[saltLength];
        
        rng.GetBytes(salt);

        return Convert.ToBase64String(salt);
    }
}