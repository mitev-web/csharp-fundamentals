using System;
using System.Collections.Generic;
using System.Linq;

namespace CountOccurance
{
    class Program
    {
        //Write a program that finds in given array of integers (all belonging to the range [0..1000]) how many times each of them occurs.
        //Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
        //2  2 times
        //3  4 times
        //4  3 times
        static void Main(string[] args)
        {
            int[] arr = new int[] { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            Dictionary<int, int> dict = new Dictionary<int, int>();

            foreach (var item in arr)
            {
                if (dict.ContainsKey(item))
                {
                    dict[item]++;
                }
                else
                {
                    dict.Add(item, 1);
                }
            }

            foreach (var item in dict)
            {
                Console.WriteLine("{0} {1} times",item.Key,item.Value);
            }
        }
    }
}