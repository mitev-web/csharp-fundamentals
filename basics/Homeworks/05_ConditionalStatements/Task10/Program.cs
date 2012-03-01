using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task10
{
    class Program
    {
        static void Main(string[] args)
        {
      //Write a program that applies bonus scores to given scores in the range [1..9]. 
            //The program reads a digit as an input. If the digit is between 1 and 3, the program multiplies 
            //it by 10; if it is between 4 and 6, multiplies it by 100; if it is between 7 and 9, multiplies it by 1000. 
            //If it is zero or if the value is not a digit, the program must report an error.
		//Use a switch statement and at the end print the calculated new value in the console.

            int digit;
            Console.Write("enter a a digit between (1-9) ");
            string input = Console.ReadLine();
            
            IEnumerable<int> range = Enumerable.Range(1, 9);
            int.TryParse(input, out digit);
            byte scenario = 0;

            
            if (Enumerable.Range(1, 3).Contains(digit))
            {
                scenario = 1;
            }
            if (Enumerable.Range(4, 6).Contains(digit))
            {
                scenario = 2;
            }
            if (Enumerable.Range(7, 9).Contains(digit))
            {
                scenario = 3;
            }

            switch (scenario)
            {
                case 1: digit *= 10; Console.WriteLine(digit); break;
                case 2: digit *= 100; Console.WriteLine(digit); break;
                case 3: digit *= 1000; Console.WriteLine(digit); break;
            }

            
        }
    }
}
