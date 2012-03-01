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
            //Write a program to print the first 100 members of the sequence of Fibonacci: 
            //0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …
            ulong currentFibonacciNumber = 0;
            ulong a = 0;
            ulong b = 1;

            for (int i = 0; i < 99; i++)
            {
                currentFibonacciNumber = a + b;
                a = b;
                b = currentFibonacciNumber;
                Console.WriteLine(currentFibonacciNumber);
            }

        }
    }
}
