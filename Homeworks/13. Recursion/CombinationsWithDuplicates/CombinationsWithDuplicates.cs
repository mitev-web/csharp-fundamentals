using System;
using System.Linq;

namespace NestedLoopsForK
{
    class CombinationsWithDuplicates
    {
        //Write a recursive program that simulates execution of n nested loops from 1 to n
        static void Main(string[] args)
        {
            int N = 3;
            int[] arr = new int[N];
            Generate(arr, N - 1, N);
        }

        static void Generate(int[] arr, int startIndex, int endIndex)
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

                    Generate(arr, startIndex - 1, endIndex);
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