using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StudyShare.Application.Utilities
{
    public class KeywordUtilities
    {
        public static bool IsValidKeywordFormat(string keyword)
        {
            string pattern = @"^(?=.*[a-zA-Z0-9À-ÖØ-öø-ÿ])[a-zA-Z0-9À-ÖØ-öø-ÿ]{2,30}$";
            return Regex.IsMatch(keyword, pattern);
        }
        public static string FormattingKeyword(string keyword)
        {
            return char.ToUpper(keyword[0]) + keyword.Substring(1);
        }
    }
}