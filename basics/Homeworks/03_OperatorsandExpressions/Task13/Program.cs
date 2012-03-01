using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task13
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.

            Console.WriteLine("Please enter integer");
            uint number;
            string line = Console.ReadLine();
            uint.TryParse(line, out number);
            Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0'));

            byte firstPosition = 3;
            byte secondPosition = 24;

            uint first3bits;
            uint last3bits;
            Console.WriteLine("moving first 3 bits");
            first3bits = number >> firstPosition;
            Console.WriteLine(Convert.ToString(first3bits, 2).PadLeft(32, '0'));
            first3bits = first3bits << secondPosition;
            Console.WriteLine(Convert.ToString(first3bits, 2).PadLeft(32, '0'));

            Console.WriteLine("moving first 3 bits");
            last3bits = number << 6;
            Console.WriteLine(Convert.ToString(last3bits, 2).PadLeft(32, '0'));
            last3bits = last3bits >> 26 ;
            Console.WriteLine(Convert.ToString(last3bits, 2).PadLeft(32, '0'));

            Console.WriteLine("merging swapped bits in one number");
            number = first3bits | last3bits;
            Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0'));

        }
    }
}
