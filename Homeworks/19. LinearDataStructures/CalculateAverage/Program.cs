using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculateAverage
{
    class Program
    {
        //Write a program that reads from the console
        //a sequence of positive integer numbers.
        //The sequence ends when empty line is entered.
        //Calculate and print the sum and average of the 
        //elements of the sequence. Keep the sequence in List<int>.
        static void Main(string[] args)
        {
            bool input = true;
            List<int> numbers = new List<int>();
            int temp = 0;
            while (input)
            {
                if (int.TryParse(Console.ReadLine(), out temp))
                {
                    numbers.Add(temp);
                }
                else
                {
                    input = false;
                }
            }

            Console.WriteLine(numbers.Average());
        }
    }
}