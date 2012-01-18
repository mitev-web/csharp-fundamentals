﻿using System;
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
            int N = 3;
            int[] arr = new int[N];
            GeneratePermutation(N - 1, arr, N);
        }


        static void GeneratePermutation(int startIndex, int[] arr, int N)
        {

            if (startIndex == -1)
            {
                if(arr.Distinct().Count() == N)
                Print(arr);
            }
            else
            {
                for (int i = 1; i <= N; i++)
                {
                    arr[startIndex] = i;

                    GeneratePermutation(startIndex - 1, arr, N);
                }

            }

        }


        static void Print(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write("{0,2}", item);
            }
            Console.WriteLine();

        }

    }
}