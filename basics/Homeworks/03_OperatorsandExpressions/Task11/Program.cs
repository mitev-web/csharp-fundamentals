using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task11
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write an expression that extracts from a given integer i the value of a given bit number b. Example: i=5; b=2  value=1.

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
                Console.WriteLine("The value of the bit {0} is 0", position);
            }
            else
            {
                Console.WriteLine("The value of the bit {0} is 1", position);
            }
        }
    }
}
