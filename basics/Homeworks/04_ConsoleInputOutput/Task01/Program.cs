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
            //Write a program that reads 3 integer numbers from the console
            //and prints their sum.

            int a;
            int b;
            int c;
            Console.WriteLine("Please enter first number");
            string line = Console.ReadLine();
            int.TryParse(line, out a);
            Console.WriteLine("Please enter second number");
            line = Console.ReadLine();
            int.TryParse(line, out b);
            Console.WriteLine("Please enter third number");
            line = Console.ReadLine();
            int.TryParse(line, out c);

            Console.WriteLine("The sum of three numbers is {0}", a + b + c);
        }
    }
}
