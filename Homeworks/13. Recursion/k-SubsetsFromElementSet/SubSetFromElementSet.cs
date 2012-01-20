using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace k_SubsetsFromElementSet
{
    class SubSetFromElementSet
    {
        //        Write a recursive program for generating and printing all ordered k-element subsets from n-element set (variations Vkn).
        //Example: n=3, k=2
        //(1 1), (1 2), (1 3), (2 1), (2 2), (2 3), (3 1), (3 2), (3 3)

        static void Main(string[] args)
        {
            int K = 2;
            int N = 3;
            int[] arr = new int[K];

            GenerateVariations(arr, 0, N);
           
        }

        public static void GenerateVariations(int[] arr, int startIndex, int endIndex)
        {

            if (startIndex >= arr.Length)
            {
                Print(arr);

            }
            else
            {
                for (int i = 1; i <= endIndex; i++)
                {
                    arr[startIndex] = i;
                    GenerateVariations(arr, startIndex + 1, endIndex);
                }

            }

        }

        private static void Print(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(" {0} ",item);
            }
            Console.WriteLine();
        }
   

    }
}
