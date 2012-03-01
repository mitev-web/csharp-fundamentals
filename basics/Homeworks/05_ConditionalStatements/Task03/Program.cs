using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that finds the biggest of three integers using nested if statements.
            int a = 3;
            int b = 6;
            int c = -17;

            if (a > b)
            {
                if (a > c)
                {
                    Console.WriteLine("biggest number is {0}", a);
                }

            }
            else if (b > a)
            {
                if (b > c)
                {
                    Console.WriteLine("biggest number is {0}", b);
                }
            }
            else
            {
                Console.WriteLine("biggest number is {0}", c);
            }


        }
    }
}
