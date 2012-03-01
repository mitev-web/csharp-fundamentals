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
            //Write a program that prints all the numbers from 1 to N, 
            //that are not divisible by 3 and 7 at the same time.
            Console.WriteLine("Please enter integer N");
            uint n;
            string input = Console.ReadLine();
            uint.TryParse(input, out n);
            Console.WriteLine("Numbers that are NOT divisible by 3 & 7");
            for (int i = 1; i <= n; i++)
            {
                if (i % (3 * 7) != 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
