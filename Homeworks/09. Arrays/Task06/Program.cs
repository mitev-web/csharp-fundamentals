using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task06
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that reads two integer numbers N and K 
            //and an array of N elements from the console.
            //Find in the array those K elements that have maximal sum.

            int N = int.Parse(Console.ReadLine());
            int K = int.Parse(Console.ReadLine());
            int[] arr = new int[N];
            int sum = 0;
            if (K > N) return;

            for (int i = 0; i < N; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort(arr);
            for (int i = N - K; i < N; i++)
            {
                Console.WriteLine(arr[i] + " ");
                sum += arr[i];
            }
            Console.WriteLine("Sum is {0}", sum);
        }
    }
}
