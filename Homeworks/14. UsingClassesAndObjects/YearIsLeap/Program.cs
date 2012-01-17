using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YearIsLeap
{
    class Program
    {
        //Write a program that reads a year from the console 
        //    and checks whether it is a leap. Use DateTime.

        static void Main(string[] args)
        {

            DateTime now = DateTime.Now;
            int year = now.Year;

            if (year % 400 == 0 || (year % 100 != 0 && year % 4 == 0))
            {
                Console.WriteLine("Year is leap");
            }
            else
            {
                Console.WriteLine("Year is not leap");
            }
        }
    }
}
