using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task18
{
    class Program
    {
        static void Main(string[] args)
        {
            //        * Write a program that reads an array of integers and removes 
            //        from it a minimal number of elements in such way that the remaining 
            //            array is sorted in increasing order. Print the remaining sorted array.
            //            Example:
            //{6, 1, 4, 3, 0, 3, 6, 4, 5}  {1, 3, 3, 4, 5}
            int[] arr = { 6, 1, 4, 3, 0, 3, 6, 4, 5 };

            FindOrderedElements(arr);
        }

        public static void FindOrderedElements(int[] arr)
        {
            int currentStartIndex = 0;
     
            int startIndexMaxSeq = 0;

            int currentSeq = 0;
            int maxSeq = 0;
            bool seriq = false;

            for (int i = 0; i < arr.Length - 2; i++)
            {
                if (seriq)
                {
                    if (arr[i] <= arr[i + 1])
                    {
                        currentSeq++;
                        if (currentSeq > maxSeq)
                            maxSeq = currentSeq;
                    }
                    else
                    {
                        seriq = false;

                        if (currentSeq > maxSeq)
                        {
                            maxSeq = currentSeq;
                            startIndexMaxSeq = currentStartIndex;
                        }
                        currentSeq = 0;
                    }
                }
                else
                {
                    if (arr[i] <= arr[i + 1])
                    {
                        currentSeq = 2;
                        seriq = true;
                        currentStartIndex = i;
                        if (currentSeq > maxSeq)
                        {
                            startIndexMaxSeq = currentStartIndex;
                            maxSeq = currentSeq;
                        }
                    }
                }
            }

            for (int i = startIndexMaxSeq; i < maxSeq + startIndexMaxSeq; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
    }
}