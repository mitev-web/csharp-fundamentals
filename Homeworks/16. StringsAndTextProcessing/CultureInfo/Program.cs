using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace SubstractDates
{
    class Program
    {
        //Write a program that reads two dates in the format: 
        //day.month.year and calculates the number of days between them. Example:

        //Enter the first date: 27.02.2006
        //Enter the second date: 3.03.2004
        //Distance: 4 days

        static void Main(string[] args)
        {
            DateTime dt = DateTime.Now;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");
          
            DateTime date1 = DateTime.Parse(Console.ReadLine());
            DateTime date2 = DateTime.Parse(Console.ReadLine());
            TimeSpan ts = new TimeSpan();
            if (date1 > date2)
            {
                ts = date1 - date2;
            }
            else
            {
                ts = date2 - date1;
            }

            Console.WriteLine(ts.Days);
            
        }
    }
}
