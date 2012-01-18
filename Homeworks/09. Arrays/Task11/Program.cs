using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task11
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that finds the index of given element
            //in a sorted array of integers by using the binary search algorithm
            //(find it in Wikipedia).

            int[] arr = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };
            Array.Sort(arr);

       
          Console.WriteLine(BinarySearch1(arr, -1));

        }

        static int BinarySearch1(int[] array, int value)
        {
            int low = 0, high = array.Length - 1, midpoint = 0;

            while (low <= high)
            {
                midpoint = low + (high - low) / 2;


                if (value == array[midpoint])
                {
                    return midpoint;
                }
                else if (value < array[midpoint])
                    high = midpoint - 1;
                else
                    low = midpoint + 1;
            }

            // item was not found
            return -1;
        }
    }
}
