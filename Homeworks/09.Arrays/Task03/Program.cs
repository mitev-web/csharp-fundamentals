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
            //Write a program that compares two char arrays lexicographically (letter by letter).
            char[] arr1 = { 'd', 'q', 'h', 'r' };
            char[] arr2 = { 'c', 'a', 'i', 'p' };

            for (int i = 0; i < arr1.Count(); i++)
            {
              Console.WriteLine(arr1[i].CompareTo(arr2[i]));
            }

        }
    }
}
