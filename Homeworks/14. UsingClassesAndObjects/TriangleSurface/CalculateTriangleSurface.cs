using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TriangleSurface
{
    class CalculateTriangleSurface
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("Calculate the surface of triangle \n choose method:");
            Console.WriteLine("1. Side and height");
            Console.WriteLine("2. Three sides");
            Environment.Exit(0);
            Console.WriteLine("3. Two sides and angle");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Please enter side and height");
                
                    double side = double.Parse(Console.ReadLine());
                    double height = double.Parse(Console.ReadLine());
                    Console.WriteLine(TriangleSurface(side, height));
                    break;

                case "2":
                    Console.WriteLine("Please enter 3 sides");
                    double a = double.Parse(Console.ReadLine());
                    double b = double.Parse(Console.ReadLine());
                    double c = double.Parse(Console.ReadLine());
                    Console.WriteLine(TriangleSurfaceByHeron(a, b, c));
                    break;

                case "3":
                    Console.WriteLine("Please enter 2 sides and angle");
                    a = double.Parse(Console.ReadLine());
                    b = double.Parse(Console.ReadLine());
                    double angle = double.Parse(Console.ReadLine());
                    Console.WriteLine(TriangleSurface(a, b, angle));
                    break;
            }
        }

        public static double TriangleSurface(double side, double height)
        {
            return (side * height) / 2;
        }

        public static double TriangleSurfaceByHeron(double a, double b, double c)
        {
            double p = (1 / 2) * (a + b + c);
            double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

            return s;
        }

        public static double TriangleSurface(double a, double b, double angle)
        {
            return (1 / 2) * (a * b * Math.Sin(angle));
        }
    }
}