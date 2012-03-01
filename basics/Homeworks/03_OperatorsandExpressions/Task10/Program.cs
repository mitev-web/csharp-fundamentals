using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task10
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a boolean expression that returns if the bit at position p 
            //(counting from 0) in a given integer number v has value of 1. Example: v=5; p=1  false.

            Console.WriteLine("Please enter integer");
            int number;
            int position;
            string line = Console.ReadLine();
            int.TryParse(line, out number);
            Console.WriteLine("Enter a position");
            line = Console.ReadLine();
            int.TryParse(line, out position);

            Console.WriteLine("The number in binary is");
            Console.WriteLine(Convert.ToString(number, 2).PadLeft(16, '0'));
            number = number >> position;

            if (number % 2 == 0)
            {
                Console.WriteLine("The bit at position {0} is 0", position);
            }
            else
            {
                Console.WriteLine("The bit at position {0} is 1", position);
            }
        }
    }
}
