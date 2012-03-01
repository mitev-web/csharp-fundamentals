using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task05
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that gets two numbers from the console and prints the greater of them. 
            //Don’t use if statements.

            int a = new int();
            int b = new int();

            Console.WriteLine("Please enter first number");
            string line = Console.ReadLine();
            int.TryParse(line, out a);
            Console.WriteLine("Please enter second number");
            line = Console.ReadLine();
            int.TryParse(line, out b);

            Console.WriteLine("The bigger number is {0}", a > b ? a : b);

        }
    }
}
