using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that reads the radius r of a circle and 
            //prints its perimeter and area.

            double radius;
            double pi = Math.PI;
            Console.WriteLine("Please enter the radius of circle");
            string line = Console.ReadLine();
            double.TryParse(line, out radius);

            double perimeter = 2*pi*radius;
            double area = pi * Math.Pow(radius, 2);

            Console.WriteLine("The perimeter of the circle is {0:F2}", perimeter);

            Console.WriteLine("The area is {0:F2}", area);       
        

        }
    }
}
