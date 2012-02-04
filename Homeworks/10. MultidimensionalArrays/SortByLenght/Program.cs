using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task05
{
    class Program
    {
        static void Main(string[] args)
        {
           //You are given an array of strings. Write a method that sorts 
           //the array by the length of its elements
           //(the number of characters composing them).

            string[] arr = { "test", "shahasls", "sdfsfsfs", "fsd" };


            foreach (var e in SortByLenght(arr))
            {
                Console.WriteLine(e);
            }


        }

        public static IEnumerable<string> SortByLenght(IEnumerable<string> arr)
        {
            var s = from e in arr
                    orderby e.Length
                    select e;


            return s;

        }
    }
}
