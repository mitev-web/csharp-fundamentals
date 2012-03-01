using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task10
{
    class Program
    {
        static void Main(string[] args)
        {
            //In the combinatorial mathematics, the Catalan numbers are calculated by
            //the following formula:
            //	Write a program to calculate the Nth Catalan number by given N.

            double N = new double();
            Console.WriteLine("Enter N");
            if (!double.TryParse(Console.ReadLine(), out N) || N < 0)
            {
                Console.WriteLine("Invalid Input");
            }

         Console.WriteLine("{0:F6}",1/(N+1)*(Math.Pow(N, 2*N)) - (Factorial(2*N)/(Factorial(N+1)*(Factorial(N)))));   

        }

        static double Factorial(double x)
        {
            int factorial = 1;
            for (int i = 1; i < x; i++)
            {
                factorial += factorial * i;
            }

            return factorial;
        }
    }
}
