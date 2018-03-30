using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Wiggydave10.Utilities
{
    public static class StringExtensions
    {
        private static readonly string[] units = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        private static readonly string[] tens = { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

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

        public static string GetNumberWordForm(this int number)
        {
            if (number < 20)
                return units[number];
            if (number < 100)
            {
                if ((number % 10) == 0)
                    return $"{tens[number / 10]}";
                return $"{tens[number / 10]} {units[number % 10]}";
            }
            if (number < 1000)
            {
                if ((number % 100) == 0)
                    return $"{(number / 100).GetNumberWordForm()} hundred";
                return $"{(number / 100).GetNumberWordForm()} hundred and {(number % 100).GetNumberWordForm()}";
            }
            if (number < 1000000)
            {
                if ((number % 1000) == 0)
                    return $"{(number / 1000).GetNumberWordForm()} thousand";
                return $"{(number / 1000).GetNumberWordForm()} thousand {(number % 1000).GetNumberWordForm()}";
            }
                
            return null;
        }

        public static int GetTotalAlphabeticalValue(this string text)
        {
            return text.GetAlphabeticalValue().Sum();
        }

        public static IEnumerable<int> GetAlphabeticalValue(this string text)
        {
            return text.ToUpper().ToCharArray().Select(x => x - 64);
        }

        public static bool IsPalindrome(this string value)
        {
            var frontIndex = 0;
            var endIndex = value.Length - 1;
            while (true)
            {
                if (frontIndex > endIndex)
                    return true;

                var a = value[frontIndex];
                var b = value[endIndex];

                if (char.ToLower(a) != char.ToLower(b))
                    return false;

                frontIndex++;
                endIndex--;
            }
        }
    }
}
