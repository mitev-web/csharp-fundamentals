using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SumNumbersFromString
{
    class SumNumbers
    {
        //You are given a sequence of positive integer values written into a string, 
        //separated by spaces. Write a function that reads these values from given 
        //string and calculates their sum. Example:
        //string = "43 68 9 23 318"  result = 461
        static void Main(string[] args)
        {
            Console.WriteLine("43 68 9 23 318".Split(' ').Select(x => int.Parse(x)).ToArray().Sum());
        }
    }
}