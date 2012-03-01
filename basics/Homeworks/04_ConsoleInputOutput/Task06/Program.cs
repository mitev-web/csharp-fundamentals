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
            //Write a program that reads the coefficients a, b and c of a quadratic equation
            //ax2+bx+c=0 and solves it (prints its real roots).

            int a;
            int b;
            int c;
            int d;
            double x1, x2;

            Console.WriteLine("Please enter first number");
            string line = Console.ReadLine();
            int.TryParse(line, out a);
            Console.WriteLine("Please enter second number");
            line = Console.ReadLine();
            int.TryParse(line, out b);
            Console.WriteLine("Please enter third number");
            line = Console.ReadLine();
            int.TryParse(line, out c);

            d = b * b - 4 * a * c;

            if (d == 0)
            {
                x1 = x2 = -b / (2 * a);
                Console.WriteLine("Both solutions are {0:F2}.", x1);
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
                Console.ReadLine();
            }       

        }
    }
}
