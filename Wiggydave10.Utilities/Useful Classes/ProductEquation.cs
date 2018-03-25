using System.Linq;

namespace Wiggydave10.Utilities.Useful_Classes
{
    public class ProductEquation
    {
        private decimal multiplicand;
        private decimal multiplier;
        private decimal product;

        public decimal Multiplicand
        {
            get
            {
                if (multiplicand > 0)
                    return multiplicand;
                return FindMultiplicand();
            }
            set => multiplicand = value;
        }

        public decimal Multiplier
        {
            get
            {
                if (multiplier > 0)
                    return multiplier;
                return FindMultiplier();
            }
            set => multiplier = value;
        }

        public decimal Product
        {
            get
            {
                if (product > 0)
                    return product;
                return FindProduct();
            }
            set => product = value;
        }

        public decimal FindProduct()
        {
            Product = Multiplicand * Multiplier;
            return Product;
        }

        public decimal FindMultiplier()
        {
            Multiplier = decimal.Divide(Product, Multiplicand);
            return Multiplier;
        }

        public decimal FindMultiplicand()
        {
            Multiplicand = decimal.Divide(Product, Multiplier);
            return Multiplicand;
        }

        public string GetString()
        {
            return $"{Multiplicand}{Multiplier}{Product}";
        }
    }

    public static class ProductEquationExtensions
    {
        public static bool IsPandigital(this ProductEquation productEq, int pandigital)
        {
            var str = productEq.GetString();
            var numbers = Enumerable.Range(1, pandigital);

            var distinctNumbers = str.ToCharArray().Distinct();
            if (str.Length == pandigital && distinctNumbers.Count() == pandigital)
            {
                return numbers.All(number => str.Contains(number.ToString()));
            }
            return false;
        }
    }
}
