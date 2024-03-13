using System.Text.RegularExpressions;

namespace StudyShare.Application.Utilities
{
    public class ServiceUtilities
    {
        public static bool IsValidId(int id)
        {
            return id > 0;
        }

        public static bool IsValidPassword(string password)
        {
             string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";

             return Regex.IsMatch(password, pattern);
        }

        public static bool IsValidEmail(string email)
        {
            string pattern =@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            return Regex.IsMatch(email, pattern);

        }

        public static bool IsValidName(string name)
        {
            string pattern = @"^[a-zA-Z]{3,30}";
            return Regex.IsMatch(name, pattern);
        }
    }
}