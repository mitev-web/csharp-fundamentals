using System;
using System.Linq;

namespace YearIsLeap
{
    class IsLeapYear
    {
        //Write a program that reads a year from the console 
        //    and checks whether it is a leap. Use DateTime.
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter this Year");
            DateTime enteredYear = new DateTime(int.Parse(Console.ReadLine()),1,1);
            YearIsLeap(enteredYear);
        }

        private static void YearIsLeap(DateTime enteredYear)
        {
            if (DateTime.IsLeapYear(enteredYear.Year))
            {
                Console.WriteLine("This year is leap");
            }
            else
            {
                Console.WriteLine("This year is not leap");
            }
        }
        //if (year % 400 == 0 || (year % 100 != 0 && year % 4 == 0))
        //{
        //    Console.WriteLine("Year is leap");
        //}
        //else
        //{
        //    Console.WriteLine("Year is not leap");
        //}
    }
}