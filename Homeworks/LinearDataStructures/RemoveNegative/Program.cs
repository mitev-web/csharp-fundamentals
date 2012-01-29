using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RemoveNegative
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that removes 
            //    from given sequence all negative numbers.

            List<int> numbers = new List<int> { 0,3, 3,-44, 5, 3, 4, -4, 5, 7, 7, 7, 2, 345, -11, 2, 2, 5,-355 };


            numbers = (from s in numbers
                     where s > 0
                     select s).ToList<int>();

            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }
        }
    }
}
