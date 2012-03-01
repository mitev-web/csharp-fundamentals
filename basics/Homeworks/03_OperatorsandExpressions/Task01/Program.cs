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
            //Write an expression that checks if given integer is odd or even.

            Console.WriteLine("Please enter a number");
            string line = Console.ReadLine();
            int number;
            int.TryParse(line, out number);

            if (number % 2 == 1)
            {
                Console.WriteLine("number is odd");
            }
            else
            {
                Console.WriteLine("number is even");
            }


        }
    }
}
