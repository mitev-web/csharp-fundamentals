using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exersice09
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that prints the first 10 members of the sequence:
            //2, -3, 4, -5, 6, -7, ...

            List<int> numbers = new List<int>();

            for (int i = 2; i < 12; i=i+2)
            {
                numbers.Add(i);
                numbers.Add(-(1+i));
            }

            foreach (int i in numbers)
            {
                Console.WriteLine(i);
            }


        }
    }
}
