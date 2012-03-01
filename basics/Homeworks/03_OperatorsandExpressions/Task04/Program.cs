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
            //Write an expression that checks for given integer if its third digit 
            //(right-to-left) is 7. E. g. 1732  true.
            int number;
            string line = Console.ReadLine();
            int.TryParse(line, out number);

            int newNumber = number % 1000;

            if (newNumber % 700 < 100)
            {
                Console.WriteLine("Third digit is 7");
            }
            else
            {
                Console.WriteLine("Third digit is not 7");
            }

        }
    }
}
