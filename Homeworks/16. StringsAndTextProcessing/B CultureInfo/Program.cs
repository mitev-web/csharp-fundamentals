using System;
using System.Globalization;
using System.Linq;


    class DistanceDays
    {
        static void Main(string[] args)
        {
            CultureInfo provider = CultureInfo.CurrentCulture;
            string format = "d.MM.yyyy";

            Console.Write("Enter the first date: ");
            string date1 = Console.ReadLine();
            DateTime firstDate = DateTime.ParseExact(date1, format, provider);

            Console.Write("Enter the second date: ");
            string date2 = Console.ReadLine();
            DateTime secondDate = DateTime.ParseExact(date2, format, provider);

            TimeSpan result = secondDate - firstDate;
            Console.WriteLine("Distance: {0} days", result.Days);
        }
    }
