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

        public static List<DateTime> publicHollydays;


        static void Main(string[] args)
        {
            DateTime christmas = new DateTime(DateTime.Now.Year, 12, 25);
            DateTime gergjovden = new DateTime(DateTime.Now.Year, 5, 6);
            DateTime tretiMart = new DateTime(DateTime.Now.Year, 3, 3);
            publicHollydays = new List<DateTime> { christmas, gergjovden, tretiMart };

            Console.WriteLine(WorkingDaysInPeriod(DateTime.Now, DateTime.Now.AddDays(180)));
        }

        public static int WorkingDaysInPeriod(DateTime startPeriod, DateTime endPeriod)
        {
            DateTime period = endPeriod - startPeriod;


            foreach (DateTime.D d in collectionate)
            {
                
            }

        }
    }
}
