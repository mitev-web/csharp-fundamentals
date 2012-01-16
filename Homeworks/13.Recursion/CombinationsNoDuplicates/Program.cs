using System;
using System.Linq;

namespace NestedLoops
{
    class Program
    {

        //Write a recursive program that simulates execution of n nested loops from 1 to n
        static void Main(string[] args)
        {
            int size = 3;
            int[] arr = new int[size];
            Generate(size - 1, arr, size);


        }


        static void Generate(int startIndex, int[] arr, int size)
        {

            if (startIndex == -1)
            {
                Print(arr);
            }
            else
            {
                for (int i = 1; i <= size; i++)
                {
                    arr[startIndex] = i;

                    Generate(startIndex - 1, arr, size);
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
