using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task06
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program that enters the coefficients a, b and c of a quadratic equation
		//a*x2 + b*x + c = 0
		//and calculates and prints its real roots. Note that quadratic equations may have 0, 1 or 2 real roots.

            int a;
            int b;
            int c;
            int d;
            double x1, x2;

            Console.WriteLine("Please enter a");
            string line = Console.ReadLine();
            int.TryParse(line, out a);
            Console.WriteLine("Please enter b");
            line = Console.ReadLine();
            int.TryParse(line, out b);
            Console.WriteLine("Please enter c");
            line = Console.ReadLine();
            int.TryParse(line, out c);

            d = b * b - 4 * a * c;

            if (d == 0)
            {
                x1 = x2 = -b / (2 * a);
                Console.WriteLine("Both roots are equal to {0:F2}.", x1);
            }
            else if (d < 0)
            {
                Console.WriteLine("No solutions for the equation!");
            }
            else
            {
                x1 = (-b - Math.Sqrt(d)) / (2 * a);
                x2 = (-b + Math.Sqrt(d)) / (2 * a);
                Console.WriteLine("The x1 = {0:F2} x2 = {1:F2}.", x1, x2);

            }       

        }
    }
}
