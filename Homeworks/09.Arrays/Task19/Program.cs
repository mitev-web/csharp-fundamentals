using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task19
{
    class Program
    {
     
    //        * Write a program that reads a number N and generates and prints 
    //            all the permutations of the numbers [1 … N]. Example:
    //n = 3  {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2}, {3, 2, 1}

        static void Main(string[] args)
        {
            int size = 3;
            int[] arr = new int[size];
            Generate(size - 1, arr, size);
        }


        static void Generate(int startIndex, int[] arr, int size)
        {

            if (startIndex == -1)
                Print(arr);
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
