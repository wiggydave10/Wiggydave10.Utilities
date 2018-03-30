namespace Wiggydave10.Utilities.Useful_Classes
{
    public class Fraction
    {
        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public decimal Result => decimal.Divide(Numerator, Denominator);
    }

    public static class FractionExtensions
    {
        public static Fraction Multiply(this Fraction fractionA, Fraction fractionB)
        {
            return new Fraction(fractionA.Numerator * fractionB.Numerator, fractionA.Denominator * fractionB.Denominator);
        }

        public static Fraction CancelFraction(this Fraction fraction)
        {
            var greatestCommonDivisor = MathUtilities.GetGreatestCommonDivisor(fraction.Numerator, fraction.Denominator);
            return new Fraction(fraction.Numerator / greatestCommonDivisor, fraction.Denominator / greatestCommonDivisor);
        }
    }
}