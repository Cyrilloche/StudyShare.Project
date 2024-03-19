using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StudyShare.Application.Utilities
{
    public class PaperUtilities
    {
        public static bool IsValidName(string name)
        {
            string pattern = @"^[^<>:""/\\|?*\x00-\x1F]{1,255}$";
            return Regex.IsMatch(name, pattern);
        }
        public static string FormattingPaperName(string name)
        {
            return DateTime.Now.ToString("yyyyMMdd") + "_" + name.Trim().ToLower().Replace(" ", "_");
        }

    }
}