using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task20
{
    class Program
    {
        static void Main(string[] args)
        {
    //        Write a program that reads two numbers N and K and generates all
    //            the variations of K elements from the set [1..N]. Example:
    //N = 3, K = 2  {1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}

            int K = 2;
            int N = 3;
            int[] arr = new int[N];
            Generate(N - 1, arr, N, K);
        }

        static void Generate(int startIndex, int[] arr, int size, int limit)
        {

            if (startIndex == -1)
            {
                Print(arr, limit);
            }
            else
            {
                for (int i = 1; i <= size; i++)
                {
                    arr[startIndex] = i;
                    Generate(startIndex - 1, arr, size, limit);
                }

            }

        }


        static void Print(int[] arr, int limit)
        {
            for (int i = 0; i < limit; i++)
			{
			 Console.Write("{0,2}", arr[i]);
			}
               
            Console.WriteLine();

        }
    }
}
