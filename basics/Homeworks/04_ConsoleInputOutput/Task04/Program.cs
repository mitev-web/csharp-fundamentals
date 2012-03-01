using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that reads two positive integer numbers and prints
            //how many numbers p exist between them such that the reminder of the division 
            //by 5 is 0 (inclusive). Example: p(17,25) = 2.
            uint a;
            uint b;
            uint temp;

            Console.WriteLine("Please enter first number");
            string line = Console.ReadLine();
            uint.TryParse(line, out a);
            Console.WriteLine("Please enter second number");
            line = Console.ReadLine();
            uint.TryParse(line, out b);

            if (b < a)
            {
                temp = a;
                a = b;
                b = temp;
            }
            uint p = 0;
            for (uint i = a; i < b; i++)
            {
                if ((i % 5) == 0)
                {
                    p++;
                }
            }
            Console.WriteLine("P exists {0} times", p);
        }
    }
}
