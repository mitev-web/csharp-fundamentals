using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckForBiggerNeighborsII
{
    class Program
    {

        //        Write a method that returns the index of the first element in array 
        //that is bigger than its neighbors, or -1, if there’s no such element.
        //Use the method from the previous exercise.

        static void Main(string[] args)
        {
            int[] arr = { 2, 5, 6, 2, 8, 93, 5, 2, 6, 673, 2, 5, 7, 83, 65 };
            Console.WriteLine(GetFirstElementWithSmallerNeighbors(arr));
        }



        public static int GetFirstElementWithSmallerNeighbors(int[] arr)
        {
            int result = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                result = CheckForBiggerNeighbors(i, arr);
                if (result > 0)
                {
                    return result;
                }
            }
            return -1;
        }

        public static int CheckForBiggerNeighbors(int position, int[] arr)
        {

            if (position >= arr.Length - 1 || position <= 1) return -1;


            if (arr[position] > (arr[position + 1] + arr[position - 1]))
            {

                return position;
            }
            else
            {
                return -1;
            }
        }
    }
}
