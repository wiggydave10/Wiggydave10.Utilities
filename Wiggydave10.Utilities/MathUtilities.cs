using System.Collections.Generic;
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

        public static IEnumerable<int> GetDigits(int integer)
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
    }
}