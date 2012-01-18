using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AscendingDescendingSort
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a method that return the maximal element in a portion of array of 
            //    integers starting at given index. Using it write another method that 
            //sorts an array in ascending / descending order.

            int[] arr = { 2, 5,932,42,5,21,5,64,2,65,0,-34,-2,2342,1,24,91 };
            bool ascending = false;

            SortArray(arr, ascending);

            foreach (var item in arr) Console.WriteLine(item);
  

        }

        public static int GetMaxInArrayRange(int startIndex, int[] arr)
        {
            int max = arr[startIndex];
            int maxPos = startIndex;

            for (int i = startIndex; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i]; 
                    maxPos = i;
                }
            }


            return maxPos;
        }

        public static void SortArray(int[] arr, bool ascending = true)
        {
            int max = 0;
            int temp = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                max = GetMaxInArrayRange(i, arr);
                temp = arr[i];
                arr[i] = arr[max];
                arr[max] = temp;
            }

            if (ascending == false)
            {
                for (int i = 0, k = arr.Length - 1; i < arr.Length/2; i++, k--)
                {
                    temp = arr[k];
                    arr[k] = arr[i];
                    arr[i] = temp;
                }

            }       
        }
    }
}
