namespace StudyShare.Application.Utilities
{
    public class HashUtilities
    {
        public static string HashPassword(string password) => BCrypt.Net.BCrypt.EnhancedHashPassword(password, 13);
        public static bool VerifyPassword(string password, string passwordHash)
        {
            bool check = BCrypt.Net.BCrypt.EnhancedVerify(password, passwordHash);
            return check;
        }
    }
}