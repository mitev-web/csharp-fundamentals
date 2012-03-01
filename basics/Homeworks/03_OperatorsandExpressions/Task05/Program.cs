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
            //Write a boolean expression for finding if the bit 3 
            //(counting from 0) of a given integer is 1 or 0.

            Console.WriteLine("Please enter integer");
            int number;
            string line = Console.ReadLine();
            int.TryParse(line, out number);

            string numberStr = Convert.ToString(number, 2).PadLeft(16, '0');
            Console.WriteLine("the number in binary {0}", numberStr);

            number = number >> 0x3;
            if ((number % 2) == 1)
            {
                Console.WriteLine("third bit is 1");
            }
            else
            {
                Console.WriteLine("third bit is 0");
            }

            Console.WriteLine(Convert.ToString(number, 2).PadLeft(16, '0'));

            //another way to solve this task
            //char thirdBit = numberStr[numberStr.Length - 4];
            //Console.WriteLine("Third bit is {0}", thirdBit);

        }
    }
}
