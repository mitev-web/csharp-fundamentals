using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckForBiggerNeighbors
{
    class Program
    {
        //Write a method that checks if the element at given position in given array
        //    of integers is bigger than its two neighbors (when such exist).

        static void Main(string[] args)
        {
            Random rand = new Random();
            int[] arr = { 2, 5, 6, 2, 8, 93, 5, 2, 6, 673, 2, 5, 7, 83, 65 };
            int position = rand.Next(arr.Length);

            if (CheckForBiggerNeighbors(position, arr))
            {
                Console.WriteLine("Number {0} at position {1} is bigger than its Neighbors", arr[position], position);
            }
            else
            {
                Console.WriteLine("Number {0} at position {1} is NOT bigger than its Neighbors or dont' have Neighbors", arr[position], position);
            }

        }

        public static bool CheckForBiggerNeighbors(int position, int[] arr)
        {

            if (position >= arr.Length - 1 || position <= 1)
            {
                return false;
            } 

            if (arr[position] > (arr[position + 1] + arr[position - 1]))
            {

                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
