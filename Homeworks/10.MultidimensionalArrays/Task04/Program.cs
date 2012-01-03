using System;
using System.Linq;

namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program, that reads from the console an array
            //    of N integers and an integer K, sorts the array and 
            //using the method Array.BinSearch() finds the largest number 
            //in the array which is ≤ K. 

            int K = 9;
            int[] arr = { 3, 52, 5, 77 };

            Array.Sort(arr);

            int exist = Array.BinarySearch(arr, K);

            if (arr[0] > K)
            {
                Console.WriteLine("There is no solution");
                return;
            }


            if (exist >= 0)
            {
                Console.WriteLine("The number {0} exists at postion {1}", K, exist);
            }
            else
            {

                for (int i = 1; i < K; i++)
                {
                    exist = Array.BinarySearch(arr, K - i);

                    if (exist >= 0)
                    {
                        Console.WriteLine("The number {0} exists at postion {1}", K - i, exist);
                        break;
                    }
                }

            }

        }
    }
}
