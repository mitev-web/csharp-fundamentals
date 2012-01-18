using System;
using System.Linq;
using System.Numerics;

namespace Factorial
{
    class Program
    {

        //Write a program to calculate n! for each n in the range [1..100].
        //Hint: Implement first a method that multiplies a number represented 
        //    as array of digits by given integer number. 

        static void Main(string[] args)
        {
            Console.WriteLine(Factorial(100));

        }


        static BigInteger Factorial(int x)
        {
            BigInteger fact = 1;
            for (int i = 1; i < x; i++) fact += fact * i;

            return fact;
        }
    }
}
