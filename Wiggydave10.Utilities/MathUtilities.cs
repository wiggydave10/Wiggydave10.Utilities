using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Wiggydave10.Utilities
{
    public static class MathUtilities
    {
        public static bool IsEven(int number) => number % 2 == 0;
        public static bool IsOdd(int number) => number % 2 != 0;

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

        public static bool IsPrime(int number)
        {
            var isOdd = IsOdd(number);
            if (number == 2)
                return true;
            if (number == 1 || !isOdd)
                return false;

            var maxValue = Math.Floor(Math.Sqrt(number));

            for (var i = 3; i <= maxValue; i += 2)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }

        public static int GetLowestCommonMultiple(params int[] numbers)
        {
            if (numbers.Length == 1)
                return numbers[0];

            var a = numbers[0];
            var b = numbers[1];
            if (numbers.Length > 2)
                b = GetLowestCommonMultiple(numbers.Skip(1).ToArray());

            return GetLowestCommonMultiple(a, b);
        }
        public static int GetLowestCommonMultiple(int a, int b)
        {
            var x = a > b ? a : b;
            var y = a > b ? b : a;

            for (var i = 1; i < y; i++)
            {
                if ((x * i) % y == 0)
                    return i * x;
            }
            return x * y;
        }


        public static int GetGreatestCommonDivisor(params int[] numbers)
        {
            if (numbers.Length == 1)
                return numbers[0];

            var a = numbers[0];
            var b = numbers[1];
            if (numbers.Length > 2)
                b = GetGreatestCommonDivisor(numbers.Skip(1).ToArray());

            return GetGreatestCommonDivisor(a, b);
        }
        public static int GetGreatestCommonDivisor(int a, int b)
        {
            var x = a > b ? a : b;
            var y = a > b ? b : a;
            
            while (x % y != 0)
            {
                var temp = x;
                x = y;
                y = temp % x;
            }
            return y;
        }
    }
}