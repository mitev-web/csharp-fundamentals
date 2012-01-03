using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task15
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that finds all prime numbers in the range [1...10 000 000].
            //    Use the sieve of Eratosthenes algorithm (find it in Wikipedia).
            int num;
            bool[] flags = new bool[51];
            long i, k;
            int count = 0;

            num = System.Convert.ToInt32(args[0]);
            if (num < 1) num = 1;

            while (num-- > 0)
            {
                count = 0;
                for (i = 2; i <= 50; i++)
                {
                    flags[i] = true;
                }
                for (i = 2; i <= 50; i++)
                {
                    if (flags[i])
                    {
                        for (k = i + i; k <= 50; k += i)
                        {
                            flags[k] = false;
                        }
                        count++;
                    }
                }
            }

            Console.WriteLine("Count: " + count.ToString());
         
        }
    }
}
