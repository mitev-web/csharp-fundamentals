using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkingDays
{
    class WorkingDays
    {
        //Write a method that calculates the number of workdays between today and given date,
        //    passed as parameter. Consider that workdays are all days from Monday to Friday
        //        except a fixed array of public holidays specified preliminary as array.
        static void Main(string[] args)
        {
            DateTime christmas = new DateTime(DateTime.Now.Year, 12, 25);
            DateTime gergjovden = new DateTime(DateTime.Now.Year, 5, 6);
            DateTime tretiMart = new DateTime(DateTime.Now.Year, 3, 3);

            DateTime[] holidays = { christmas, gergjovden, tretiMart };

            DateTime today = DateTime.Now.Date;
            DateTime endPeriod = DateTime.Now.Date.AddDays(180);

            Console.WriteLine(BusinessDaysInPeriod(today, endPeriod, holidays));
        }

        public static double BusinessDaysInPeriod(DateTime startPeriod, DateTime endPeriod, DateTime[] holidays)
        {
            startPeriod = startPeriod.Date;
            endPeriod = endPeriod.Date;

            //TODO: calculate correctly the weekends
            TimeSpan period = endPeriod.Subtract(startPeriod);

            int businessDays = period.Days + 1;

            int weeks = businessDays / 7;
            int weekEndDays = weeks * 2;

            businessDays -= weekEndDays;
            foreach (DateTime holiday in holidays)
            {
                DateTime h = holiday.Date;
                if (startPeriod <= h && h <= endPeriod)
                    --businessDays;
            }

            return businessDays;
        }
    }
}