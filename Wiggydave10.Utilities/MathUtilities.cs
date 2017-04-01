using System.Numerics;

namespace Wiggydave10.Utilities
{
    public static class MathUtilities
    {
        public static BigInteger Power(int number, int toPower)
        {
            var result = new BigInteger();
            for (var i = 0; i < toPower; i++)
                result = result * number;

            return result;
        }
    }
}