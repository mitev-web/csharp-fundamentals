using System;
using System.Collections.Generic;
using System.Linq;


namespace Task08
{
    class Program
    {
        static void Main(string[] args)
        {
    //        Write a program that finds the sequence of maximal sum in given array. 
    //        Example:
    //{2, 3, -6, -1, 2, -1, 6, 4, -8, 8}  {2, -1, 6, 4}
    //Can you do it with only one loop (with single scan through the elements of the array)?


            int[] arr = {2, 3, -6, -1, 2, -1, 6, 4, -8, 8};

            
            MaxSubSeqSum(arr);
        }

        static void MaxSubSeqSum(int[] myArr)
        {
            int maxSum = 0;
            int currentSum = 0;
            int sequenceStart = 0;
            int sequenceEnd = 0;
            int start = 0;
            for (int i = 0; i < myArr.Length; ++i)
            {
                currentSum += myArr[i];
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    sequenceStart = start;
                    sequenceEnd = i;
                }
                else if (currentSum < 0)
                {
                    start = i + 1;
                    currentSum = 0;
                }
            }
            Console.WriteLine(maxSum);
        } 
        
    }
}
