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
            //Write a program to calculate the sum (with accuracy of 0.001): 
            //1 + 1/2 - 1/3 + 1/4 - 1/5 + ...

            decimal currentNumber = 1M;
            decimal sum = 1M;
            uint counter = 1;

            for (int i = 2; i < 999999; i++)
            {
                Console.WriteLine("{0:F3}", sum);
                if (currentNumber - 0.001M < 0)
                {
                    break;
                }
                currentNumber = 1 / (decimal)i;
                sum += currentNumber;

                counter++;
            }
            Console.WriteLine("The sum of the first {0} numbers is {1:F3}", counter, sum);
        }


    }
}
