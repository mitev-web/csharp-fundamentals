﻿using System;
using System.Linq;

namespace NestedLoops
{
    class CombinationsNoDuplicates
    {
        //Write a recursive program that simulates execution of n nested loops from 1 to n
        static void Main(string[] args)
        { 
            int N = 4;
            int[] arr = new int[N];
            GenerateVariations(arr, N - 1, N);
        }

        static void GenerateVariations(int[] arr, int startIndex, int endIndex)
        {
            if (startIndex == -1)
            {
                Print(arr);
            }
            else
            {
                for (int i = 1; i <= endIndex; i++)
                {
                    arr[startIndex] = i;

                    GenerateVariations(arr, startIndex - 1, endIndex);
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