using System;
using System.Linq;

namespace Fraction
{
    class Fraction
    {
        public decimal numerator { get; set; }
        public decimal denominator { get; set; }
        public decimal fraction { get; set; }
        public decimal decimalValue { get; set; }



        public Fraction(decimal numerator, decimal denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
            this.fraction = numerator / denominator;

            int tempNumber = Convert.ToInt32(fraction / 0.25m);
            this.decimalValue = tempNumber * 0.25m;
        }

        public static Fraction Parse(string inputString)
        {
            string[] numbers = inputString.Split('/');
            decimal numerator = decimal.Parse(numbers[0]);
            decimal denominator = decimal.Parse(numbers[1]);

            return new Fraction(numerator, denominator);
        }
    }
}
