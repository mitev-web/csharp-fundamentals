using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        //Write a boolean expression that checks for given integer 
            //if it can be divided (without remainder) by 7 and 5 in the same time.
        {
            Console.WriteLine("Please enter a number");
            string line = Console.ReadLine();
            int number;
            int.TryParse(line, out number);

            if (number % (7*5) == 0)
            {
                Console.WriteLine("number can be divided (without remainder) by 7 and 5 in the same time.");
            }
            else
            {
                Console.WriteLine("number can not be divided (without remainder) by 7 and 5");
            } 


        }
    }
}
