using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CountNumberInArray
{
    class CountNumbers
    {
        static void Main(string[] args)
        {
            //Write a method that counts how many times given number appears in given array.
            //Write a test program to check if the method is working correctly.
            int number = 5;

            int[] arr = { 5, 3, 6, 6, 2, 5 };

            Console.WriteLine(CountNumberInArray(number,arr));
        }

        public static int CountNumberInArray(int number, int[] arr)
        {
            return (from n in arr where n == number select n).Count();
        }


    }
}
