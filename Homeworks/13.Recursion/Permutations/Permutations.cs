using System;
using System.Linq;

namespace Permutations
{
    class Permutations
    {
    //    Write a recursive program for generating and printing all permutations
    //        of the numbers 1, 2, ..., n for given integer number n. Example:
    //n=3  {1, 2, 3}, {1, 3, 2}, {2, 1, 3},
    //{2, 3, 1}, {3, 1, 2},{3, 2, 1}
        static void Main(string[] args)
        {
            int N = 2;
            int[] arr = new int[N];

            GeneratePermunation(N - 1, arr, N);
        }
  
        private static void GeneratePermunation(int startindex, int[] arr, int N)
        {
            if (startindex == -1)
            {
                PrintArray(arr);
            }
            else
            {
                for (int i = 0; i < N; i++)
                {
                    startindex = startindex - 1;
                    GeneratePermunation(startindex, arr, N);
                }

            }
        }
  
        private static void PrintArray(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write("{0:00}",item);
            }
            Console.WriteLine();
        }
    }
}
