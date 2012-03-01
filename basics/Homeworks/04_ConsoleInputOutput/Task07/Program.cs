using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task07
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that gets a number n and after that gets more n numbers
            //and calculates and prints their sum. 
            uint n;
            int currentNumber;
            List<int> numbers = new List<int>();

            Console.WriteLine("Please enter a positive number");
            string input = Console.ReadLine();


            if (!uint.TryParse(input, out n))
            {
                Console.WriteLine("n");
                return;
            }


           
            for (int i = 0; i < n; i++)
            {
             Console.WriteLine("Enter any number");
                input = Console.ReadLine();

                int.TryParse(input, out currentNumber);
                numbers.Add(currentNumber);
            }
            Console.WriteLine("The sum of all numbers is {0}", numbers.Sum());

        }

    }
}
