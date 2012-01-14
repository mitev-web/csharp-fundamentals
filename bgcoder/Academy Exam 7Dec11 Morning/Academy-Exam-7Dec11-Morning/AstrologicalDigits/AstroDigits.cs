using System;
using System.Collections.Generic;
using System.Linq;

class AstrologicalDigits
    {
        static void Main(string[] args)
        {
            string N = Console.ReadLine();
            List<int> numbers = new List<int>();

            int number = 0;
            int sum = 10;

            while (sum > 9)
            {
                sum = 0;
                numbers.Clear();
                foreach (char c in N)
                {
                    int.TryParse(c.ToString(), out number);
                    numbers.Add(number);
                }
                sum = numbers.Sum();
                N = sum.ToString();
            }
            Console.WriteLine(sum);
        }
    }

