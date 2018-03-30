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
            list.Reverse();
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

        public static bool IsPrime(this int number)
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

        public static bool IsCircularPrime(this int number)
        {
            var digits = number.GetDigits();

            if (digits.Count() == 1)
                return digits.ElementAt(0).IsPrime();

            var nums = GetNumberRotation(digits);
            var isPrime = true;
            foreach (var num in nums)
            {
                var intNum = int.Parse(num);
                if (!intNum.IsPrime())
                    isPrime = false;
            }

            return isPrime;
        }

        public static IEnumerable<string> GetNumbers(string number, IEnumerable<int> digits)
        {
            if (digits.Count() == 1)
                return new []{ $"{number}{digits.ElementAt(0)}" };

            var numbers = new List<string>();
            for (var index = 0; index < digits.Count(); index++)
            {
                var digitList = digits?.ToList() ?? new List<int>();
                var digit = digitList.ElementAt(index);
                digitList.RemoveAt(index);
                var numberCopy = $"{number}{digit}";

                var numberAlternatives = GetNumbers(numberCopy, digitList);
                numbers.AddRange(numberAlternatives);
            }

            return numbers;
        }

        public static IEnumerable<string> GetNumberRotation(IEnumerable<int> digits)
        {
            var queue = new Queue<string>(digits.Select(x => x.ToString()));
            var results = new List<string>();
            foreach (var item in digits)
            {
                results.Add(queue.Aggregate((a, b) => a + b));
                queue.Dequeue();
                queue.Enqueue(item.ToString());
            }
            return results;
        }

        public static string GetBinaryNumber(this int number)
        {
            return Convert.ToString(number, 2);
        }

        public static bool IsPalindrome(this int number)
        {
            return number.ToString().IsPalindrome();
        }

        /// <summary>
        /// Please don't use, unless you want to be dumb and waste time!
        /// </summary>
        /// <param name="maxNumber"></param>
        /// <param name="includeMaxNum"></param>
        /// <returns>List of primes, eventually!</returns>
        public static IEnumerable<int> GetPrimes_VerySlow(int maxNumber, bool includeMaxNum = true)
        {
            var maxCount = includeMaxNum ? maxNumber : maxNumber - 1;
            var numbers = Enumerable.Range(1, maxCount);
            foreach (var number in numbers)
            {
                if (number.IsPrime())
                    yield return number;
            }
        }
        public static IEnumerable<int> GetPrimes(int maxNumber, bool includeMaxNum = true)
        {
            var maxCount = includeMaxNum ? maxNumber : maxNumber - 1;
            var primes = new List<int> { 2 };
            for (var index = 3; index < maxCount; index += 2)
            {
                var maxValue = Math.Floor(Math.Sqrt(index));
                var isPrime = true;
                for (int i = 0; primes[i] <= maxValue; i++)
                {
                    if (index % primes[i] == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                    primes.Add(index);
            }
            return primes;
        }
    }
}