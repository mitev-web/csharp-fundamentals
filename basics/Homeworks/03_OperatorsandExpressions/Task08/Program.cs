using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task08
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write an expression that calculates trapezoid's area by given sides a and b and height h.
            //int area = h((a + b)/2))
            string format = "centimeters";
            Console.WriteLine("Please enter side a of the trepezoid in {0}", format);
            string line = Console.ReadLine();

            double a;
            double.TryParse(line, out a);

            Console.WriteLine("Please enter side b of the trepezoid");
            line = Console.ReadLine();
            double b;
            double.TryParse(line, out b);

            Console.WriteLine("Please enter height - h of the trepezoid");
            line = Console.ReadLine();
            double h;
            double.TryParse(line, out h);


            double trapezoidArea = h * ((a + b) / 2);

            Console.WriteLine("The area of the trapezoid is {0:0.00} {1}", trapezoidArea, format);

        }
    }
}
