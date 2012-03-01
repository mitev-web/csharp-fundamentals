using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that reads from the console a sequence of N integer numbers
            //and returns the minimal and maximal of them.
            Console.WriteLine("Please enter N");
            uint n;
            string input = Console.ReadLine();
            uint.TryParse(input, out n);
            int[] arr = new int[n];
            int min = 0;
            int max = 0;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("enter integer");
                arr[i] = int.Parse(Console.ReadLine());
            }
            bool initialSet = false;

            foreach (int i in arr)
            {
                if (!initialSet)
                {
                    min = arr[i];
                    max = arr[i];
                    initialSet = true;
                }
                else
                {
                    if (min > i)
                    {
                        min = i;
                    }
                    if (max < i)
                    {
                        max = i;
                    }
                }
            }

            Console.WriteLine("Min is {0} Max is {1}", min, max);
        }
    }
}
