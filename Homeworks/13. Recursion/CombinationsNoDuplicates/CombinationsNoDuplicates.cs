using System;
using System.Linq;

namespace NestedLoops
{
    class CombinationsNoDuplicates
    {

        //Write a recursive program that simulates execution of n nested loops from 1 to n
        static void Main(string[] args)
        {
            int N = 2;
            int[] arr = new int[N];
            Generate(N - 1, arr, N);
        }


        static void Generate(int startIndex, int[] arr, int N)
        {

            if (startIndex == -1)
            {
                if (arr.Distinct().Count() == N || arr.Distinct().Count() == 1)
                Print(arr);
            }
            else
            {
                for (int i = 1; i <= N; i++)
                {
                    arr[startIndex] = i;

                    Generate(startIndex - 1, arr, N);
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
