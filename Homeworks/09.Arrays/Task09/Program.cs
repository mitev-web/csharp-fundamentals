using System;
using System.Collections.Generic;
using System.Linq;

namespace Task09
{
    class Program
    {
        static void Main(string[] args)
        {
            //        Write a program that finds the most frequent number in an array. Example:
            //{4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3}  4 (5 times)
            Dictionary<int, uint> dict = new Dictionary<int, uint>();

            int[] arr = { 7, 2, 63, 7, 5, 5, 5, 5, 7, 7, 2, 2, 6, 7, 8, 7, 1, 1, 1, 6, 7, 7, 3, 1 };

            foreach (var item in arr)
            {
                if (dict.ContainsKey(item))
                    dict[item]++;
                else
                    dict.Add(item, 1);
            }
            var k = (from e in dict
                     where e.Value == dict.Values.Max()
                     select e).First();

            Console.WriteLine("{0} times {1}", k.Value, k.Key);


        }
    }
}
