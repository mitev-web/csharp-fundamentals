using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task07
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that finds the greatest of given 5 variables.

            int a = 4234;
            int b = -11;
            int c = 3423;
            int d = 0;
            int e = 99;

            Console.WriteLine("{0} is the biggest number", Math.Max(e, Math.Max(Math.Max(a, b), Math.Max(c, d))));
               
        }
    }
}
