using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task21
{
    class Program
    {
   
    //        Write a program that reads two numbers N and K and generates 
    //        all the combinations of K distinct elements from the set [1..N]. 
    //        Example:
    //N = 5, K = 2  {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}

                    public static void Main()
        {
            int n = 5;
            int k = 2;
          
            int[] numbers = new int[n];            
            GenerateCombination(1, 0, n, k, numbers);
        }


        public static void GenerateCombination(int i, int after, 
            int n, int k, int[] numbers)
        {
            if (i > k)
            {
                return;
            }

            for (int j = after + 1; j <= n; j++)
            {
                numbers[i - 1] = j;
                if (i == k)
                {
                    PrintNumbers(numbers, i);
                }

                GenerateCombination((i + 1), j, n, k, numbers);
            }
        }

        public static void PrintNumbers(int[] numbers, int size)
        {
            for (int i = 0; i < size; i++)
            {
                Console.Write("{0} ", numbers[i]);
            }
            Console.WriteLine();
        }

 
    }
}
