using System;
using System.Text.RegularExpressions;

namespace Wiggydave10.Utilities
{
    public static class StringExtensions
    {
        public static bool IsNull(this string value)
        {
            return value == null;
        }

        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static short ToShort(this string value)
        {
            short result = 0;
            if (!value.IsNullOrEmpty())
                short.TryParse(value, out result);
            return result;
        }

        public static int ToInt(this string value)
        {
            var result = 0;
            if (!value.IsNullOrEmpty())
                int.TryParse(value, out result);
            return result;
        }

        public static long ToLong(this string value)
        {
            long result = 0;
            if (!value.IsNullOrEmpty())
                long.TryParse(value, out result);
            return result;
        }

        public static string Reverse(this string value)
        {
            var charArray = value.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static bool Match(this string value, string pattern)
        {
            return Regex.IsMatch(value, pattern);
        }
    }
}
