using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fraction
{
    class FractionTest
    {
        public FractionTest()
        {
            string test1 = "-5/23";
            string test2 = "16/4.5";
            string test3 = "21/-3.1";

            Fraction fraction = Fraction.Parse(test1);
            Console.WriteLine("Fraction is {0}", fraction.fraction);
            Console.WriteLine("Decimal Value is {0}" + Environment.NewLine, fraction.decimalValue);

            fraction = Fraction.Parse(test2);
            Console.WriteLine("Fraction is {0}", fraction.fraction);
            Console.WriteLine("Decimal Value is {0}"+Environment.NewLine, fraction.decimalValue);

            fraction = Fraction.Parse(test3);
            Console.WriteLine("Fraction is {0}", fraction.fraction);
            Console.WriteLine("Decimal Value is {0}" + Environment.NewLine, fraction.decimalValue);
        }
    }
}