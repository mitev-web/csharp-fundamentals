using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {

           // Write a program that shows the sign of the product of three real numbers
            //without calculating it. Use a sequence of if statements.


            Console.WriteLine("Please enter 3 integers");
            int a;
            int b;
            int c;
            string input = Console.ReadLine();
            int.TryParse(input, out a);
            input = Console.ReadLine();
            int.TryParse(input, out b);
            input = Console.ReadLine();
            int.TryParse(input, out c);

            uint negativeNumbers = 0;


            if (a < 0)
            {
                negativeNumbers++;
            }
            if (b < 0)
            {
                negativeNumbers++;
            }
            if (c < 0)
            {
                negativeNumbers++;
            }

            if (negativeNumbers % 2 == 1)
            {
                Console.WriteLine("The production of these numbers is negative");
            }
            else
            {
                Console.WriteLine("The production of these numbers is positive");
            }


        }
    }
}
