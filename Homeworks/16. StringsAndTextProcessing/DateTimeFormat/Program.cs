using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DateTimeFormat
{
    class Program
    {
        //Write a program that reads a date and time given in the format:
        //day.month.year hour:minute:second and prints the date and time 
        //    after 6 hours and 30 minutes (in the same format).

        static void Main(string[] args)
        {
            CultureInfo provider = CultureInfo.CurrentCulture;
            string format = "d.MM.yyyy hh:mm:ss";

            string date1 = Console.ReadLine();
            DateTime date = DateTime.ParseExact(date1, format, provider);
            Console.WriteLine(date.Hour);
            Console.WriteLine(date.Minute);

        }
    }
}
