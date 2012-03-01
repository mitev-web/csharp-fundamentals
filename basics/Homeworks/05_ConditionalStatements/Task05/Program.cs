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
            //Write program that asks for a digit and
            //depending on the input shows the name of that digit (in English) using a switch statement.

            Console.WriteLine("give me digit");
            byte digit;
            string line = Console.ReadLine();

            if (!(byte.TryParse(line, out digit) && digit < 10))
            {
                Console.WriteLine("This is not a digit");
                return;
            }

 

            switch (digit)
            {
                case 1:
                Console.WriteLine("one");
                break;
                case 2:
                Console.WriteLine("two");
                break;
                case 3:
                Console.WriteLine("three");
                break;
                case 4:
                Console.WriteLine("four");
                break;
                case 5:
                Console.WriteLine("five");
                break;
                case 6:
                Console.WriteLine("six");
                break;
                case 7:
                Console.WriteLine("seven");
                break;
                case 8:
                Console.WriteLine("eight");
                break;
                case 9:
                Console.WriteLine("nine");
                break;
                case 0:
                Console.WriteLine("zero");
                break;

            }


        }
    }
}
