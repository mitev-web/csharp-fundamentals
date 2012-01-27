using System;
using System.Collections.Generic;
using System.Linq;

namespace Phone
{
    class GSMCallHistoryTest
    {
        public GSMCallHistoryTest()
        {
            GSM gsm = new GSM("Galaxy S2", "Samsung");

            Call call1 = new Call(new DateTime(2012, 1, 22), new TimeSpan(0, 22, 30), "+35932423224");
            Call call2 = new Call(new DateTime(2012, 1, 23), new TimeSpan(0, 15, 11), "+35932413324");
            Call call3 = new Call(new DateTime(2012, 1, 24), new TimeSpan(0, 7, 30), "+3593243424");

            List<Call> callHistory = new List<Call>();
            callHistory.Add(call1);
            callHistory.Add(call2);
            callHistory.Add(call3);

            gsm.CallHistory = callHistory;

            Console.WriteLine(gsm.TotalCallsPrice(0.37M));

            //TODO:
            //Remove the longest call from the history and calculate the total price again.

            gsm.ClearCallsHistory();


        }
    }
}
