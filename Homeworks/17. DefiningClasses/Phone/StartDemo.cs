using System;
using System.Linq;

namespace Phone
{
    class StartDemo
    {
        //Create an instance of the GSM class.
        //Add few calls.
        //Display the information about the calls.
        //Assuming that the price per minute is 0.37 calculate and print the total price of the calls in the history.
        //Remove the longest call from the history and calculate the total price again.
        //Finally clear the call history and print it.
        static void Main(string[] args)
        {
            //new GSMTest();
            new GSMCallHistoryTest();
        }
    }
}