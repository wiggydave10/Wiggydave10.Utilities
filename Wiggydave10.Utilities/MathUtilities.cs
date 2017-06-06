using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Wiggydave10.Utilities
{
    public static class MathUtilities
    {
        public static BigInteger Power(int number, int toPower)
        {
            var result = new BigInteger(number);
            for (var i = 1; i < toPower; i++)
                result = result * number;

            return result;
        }

        public static IEnumerable<int> GetDigits(this int integer)
        {
            var list = new List<int>();
            while (integer > 0)
            {
                list.Add((integer % 10));
                integer = integer / 10;
            }
            return list;
        }

        public static IEnumerable<int> GetDigits(this BigInteger integer)
        {
            var list = new List<int>();
            while (!integer.IsZero)
            {
                list.Add((int)(integer % 10));
                integer = integer / 10;
            }
            return list;
        }

        public static int GetTriangleNumber(int index)
        {
            var answer = 0;
            for (var i = 1; i <= index; i++)
            {
                answer = answer + i;
            }
            return answer;
        }

        public static int Factorial(int number)
        {
            if (number == 0)
                return 1;

            return number * Factorial(number-1);
        }

        public static BigInteger Factorial(BigInteger number)
        {
            if (number == 0)
                return 1;

            return number * Factorial(number - 1);
        }

        public static IEnumerable<int> GetDivisors(int number)
        {
            IList<int> result = new List<int>();
            var squareRoot = Math.Sqrt(number);
            for (var i = 1; i <= Math.Truncate(squareRoot); i++)
            {
                if (number % i != 0)
                    continue;

                result.Add(i);
                result.Add(number / i);
            }
            return result.Distinct().OrderBy(x => x);
        }

        public static IEnumerable<int> GetDivisors(int number, bool includeNumber)
        {
            var result = GetDivisors(number);
            if (!includeNumber)
                result = result.Where(x => x != number);
            return result;
        }

        public static bool IsPerfect(this int number)
        {
            return MathUtilities.GetDivisors(number, false).Sum() == number;
        }

        public static bool IsDeficient(this int number)
        {
            return MathUtilities.GetDivisors(number, false).Sum() < number;
        }

        public static bool IsAbundent(this int number)
        {
            return MathUtilities.GetDivisors(number, false).Sum() > number;
        }
    }
}