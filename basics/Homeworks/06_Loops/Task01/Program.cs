using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that prints all the numbers from 1 to N.
            uint n;
            string input = Console.ReadLine();
            uint.TryParse(input, out n);

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(i);
            }

        }
    }
}
