using System;
using System.Collections.Generic;
using System.Linq;


namespace Task08
{
    class Program
    {
        //        Write a program that finds the sequence of maximal sum in given array. 
        //        Example:
        //{2, 3, -6, -1, 2, -1, 6, 4, -8, 8}  {2, -1, 6, 4}
        //Can you do it with only one loop (with single scan through the elements of the array)?
        static void Main(string[] args)
        {
            int[] array = { -10, -3, -6, -10, -4, -14, -6, -1, -8, -7 };
            int maxSum = array.Max();
            int sum = 0;
            int sequenceStart = Array.IndexOf(array, array.Max());
            int someStart = 0;
            int sequenceEnd = sequenceStart;
            for (int i = 0; i < array.Length; i++)
            {
                if (sum < 0)
                {
                    someStart = i;
                    sum = 0;
                }
                sum += array[i];
                if (sum > maxSum)
                {
                    maxSum = sum;
                    sequenceStart = someStart;
                    sequenceEnd = i;
                }
            }
            for (int j = sequenceStart; j <= sequenceEnd; j++)
            {
                Console.Write("{0} ", array[j]);
            }
            Console.WriteLine();
        }
        
    }
}
