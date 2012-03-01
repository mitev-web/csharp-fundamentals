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
            //Write an expression that checks if given positive integer number 
            //n (n ≤ 100) is prime. E.g. 37 is prime.

            List<int> primeNumbers = new List<int>();

            for (int number = 2; number <= 100; number++)
            {
                bool prime = true;
                for (int divider = 2; divider <= Math.Sqrt(number); divider++)
                {
                    if ((number % divider == 0))
                    {
                        prime = false;
                    }
               }
                if (prime)
                {
                    primeNumbers.Add(number);
                }
            }
            PrintPrimeNumbers(primeNumbers);
        }

        private static void PrintPrimeNumbers(List<int> primeNumbers)
        {
            int count = 0;
            foreach (int number in primeNumbers)
            {
                count++;
                Console.WriteLine(number);
            }
            Console.WriteLine("There are {0} prime numbers in this interval", count);
        }
    }
}
