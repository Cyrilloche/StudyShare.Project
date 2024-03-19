using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyShare.Application.Utilities
{
    public class HashUtilities
    {
        public static string HashPassword(string passwordUnencrypted) => BCrypt.Net.BCrypt.EnhancedHashPassword(passwordUnencrypted, 13);
        public static bool VerifyPassword(string passwordEncrypted, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(passwordEncrypted, hashedPassword);
        }
    }
}