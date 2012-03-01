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
            //Write a program that calculates the greatest common divisor (GCD) 
            //of given two numbers. Use the Euclidean algorithm (find it in Internet).

            Console.WriteLine("Enter first integer");
            long a = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter second integer");
            long b = long.Parse(Console.ReadLine());
            Console.WriteLine("Greatest Commond Divisor is:");
            Console.WriteLine(FindGreatestCommonDivisor(a, b));
        }

        static long FindGreatestCommonDivisor(long a, long b)
        {

            if (b == 0)
            {
                return a;
            }
            else
            {
                return (FindGreatestCommonDivisor(b, a % b));
            }

        }
      }
}
