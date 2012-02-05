using System;
using System.Linq;

namespace Phone
{
    class GSMCallHistoryTest
    {
        public GSMCallHistoryTest()
        {
            //creating gsm
            GSM gsm = new GSM("Samsung", "A35");

            //creating some calls
            Console.WriteLine("Adding call with duration {0} minutes and {1} seconds", 20, 30);
            Call call1 = new Call(new DateTime(2012, 1, 22), new TimeSpan(0, 22, 30), "+35932423224");
            Console.WriteLine();
            Console.WriteLine("Adding call with duration {0} minutes and {1} seconds", 15, 11);
            Call call2 = new Call(new DateTime(2012, 1, 23), new TimeSpan(0, 15, 11), "+35932413324");
            Console.WriteLine();
            Console.WriteLine("Adding call with duration {0} minutes and {1} seconds", 7, 30);
            Call call3 = new Call(new DateTime(2012, 1, 24), new TimeSpan(0, 7, 30), "+3593243424");
            Console.WriteLine();

            Console.WriteLine("Adding calls to call history");
            Console.WriteLine();

            //adding calls to call history
            gsm.CallHistory.Add(call1);
            gsm.CallHistory.Add(call2);
            gsm.CallHistory.Add(call3);

            //calculating total price
            Console.WriteLine("Total call price:");

            Console.WriteLine(gsm.TotalCallsPrice(0.37M));
            Console.WriteLine();
            //finding longest call
            Call longestCall = (from e in gsm.CallHistory
                                orderby e.Duration descending
                                select e).First();

            //removing longest call

            gsm.CallHistory.Remove(longestCall);

            //calculating price again
            Console.WriteLine("Total call price after longest call has been removed:");

            Console.WriteLine(gsm.TotalCallsPrice(0.37M));
            //clearing history
            Console.WriteLine("History cleared!");
            Console.WriteLine();
            gsm.ClearCallsHistory();
        }
    }
}