using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task22
{
    class Program
    {
    //    Write a program that reads two numbers N and K and generates all the combinations of K distinct elements from the set [1..N]. Example:
    //N = 5, K = 2  {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}

        static void Main(string[] args)
        {
            int K = 2;
            int N = 3;
            int[] arr = new int[N];
            Generate(N - 1, arr, N, K);
        }

        static void Generate(int startIndex, int[] arr, int size, int limit)
        {

            if (startIndex == -1)
            {
                PrintDistinct(arr, limit);
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


        static void PrintDistinct(int[] arr, int limit-1)
        {

            var distinct = (from e in arr
                           select e).Distinct().ToArray();
                           


          for(int i = 0; i<limit;i++){
                Console.Write("{0,2}", distinct[i]);
            }

            Console.WriteLine();

        }
    }
}
