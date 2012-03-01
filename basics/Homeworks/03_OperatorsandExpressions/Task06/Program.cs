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
            //Write an expression that checks if given point (x,  y) is within a circle K(O, 5).

            Console.WriteLine("enter X coordinate");
            double x;
            string line = Console.ReadLine();
            double.TryParse(line, out x);

            Console.WriteLine("enter Y coordinate");
            double y;
            line = Console.ReadLine();
            double.TryParse(line, out y);

            double AB = Math.Sqrt(Math.Pow((0 - x), 2) + Math.Pow((0 - y), 2));

            Console.WriteLine("The distance between A & B is {0:0.00}", AB);
            if (AB < 5)
            {
                Console.WriteLine("The point is within the circle's radius");
            }
            else
            {
                Console.WriteLine("The point is not within the circle");
            }

        }
    }
}
