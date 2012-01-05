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

        public static void Main()
        {
            int n = 4;
            int[] used = new int[n];
            int[] numbers = new int[n];
            GeneratePermutation(0, n, used, numbers);

        }

        public static void GeneratePermutation(int i, int n, int[] used, int[] numbers)
        {
            if (i >= n)
            {
                PrintNumbers(numbers);
                return;
            }

            for (int k = 0; k < n; k++)
            {
                if (used[k] == 0)
                {
                    used[k] = 1;
                    numbers[i] = k + 1;
                    GeneratePermutation((i + 1), n, used, numbers);
                    used[k] = 0;
                }
            }
        }

        public static void PrintNumbers(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write("{0} ", numbers[i]);
            }
            Console.WriteLine();
        }
    }
}
