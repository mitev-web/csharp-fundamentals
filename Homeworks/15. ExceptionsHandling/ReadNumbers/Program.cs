using System;
using System.Linq;

namespace ReadNumbers
{
    class Program
    {
        //Write a method ReadNumber(int start, int end) that enters
        //an integer number in given range [start..end]. 
        //If invalid number or non-number text is entered, 
        //the method should throw an exception. 
        //Based on this method write a program that enters 10 numbers:
        //a1, a2, … a10, such that 1 < a1 < … < a10 < 100

        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                ReadNumber(1, 100);
            }
        }

        private static void ReadNumber(int start, int end)
        {
            int number = 0;
            int.TryParse(Console.ReadLine(), out number);

            if (number < start || number > end)
            {
                throw new FormatException("The number is not within allowed range");
            }
        }
    }
}