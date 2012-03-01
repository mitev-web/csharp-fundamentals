using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task09
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write an expression that checks for given point (x, y) 
            //if it is within the circle K( (1,1), 3) and out of the rectangle 
            //R(top=1, left=-1, width=6, height=2).

            Console.WriteLine("enter X coordinate of the point");
            double x;
            string line = Console.ReadLine();
            double.TryParse(line, out x);

            Console.WriteLine("enter Y coordinate of the point");
            double y;
            line = Console.ReadLine();
            double.TryParse(line, out y);

            double AB = Math.Sqrt(Math.Pow((1 - x), 2) + Math.Pow((1 - y), 2));

            int rectangleD = 1;
            int rectangleA = -1;
            
            Console.WriteLine("The distance between A & B is {0:0.00}", AB);
            if ((x < 0 || x > 6) && (y < rectangleA || y > rectangleD))
            {
                Console.WriteLine("The point is outside of the rectangle");
            }
            else
            {
                Console.WriteLine("The point is within the rectangle's area");
            }

            if (AB < 3)
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
