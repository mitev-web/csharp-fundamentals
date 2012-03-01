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
            //Write a program that reads an integer number n from the console and prints all the numbers 
            //in the interval [1..n], each on a single line.
            int n;

            Console.WriteLine("Please enter a number");
            string line = Console.ReadLine();
            int.TryParse(line, out n);

            for (int i = 1; i <= n; i++)
            {
                Console.Write(" {0}", i);
            }
        }
    }
}
