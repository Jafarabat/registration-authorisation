
using BCrypt.Net;

namespace JWT.Models;
public class PasswordHasher
{
    public static string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public static bool VerifyHashedPassword(string HashedPassword, string password)
    {
        return BCrypt.Net.BCrypt.Verify(password, HashedPassword);
    }
}