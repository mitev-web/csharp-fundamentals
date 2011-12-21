using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task05
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that finds the maximal increasing sequence in an array. Example: {3, 2, 3, 4, 2, 2, 4}  {2, 3, 4}.

            int[] arr = { 2, 2, 63, 2, 3, 4, 5, 6, 5, 5, 5, 5, 7, 7, 2, 2, 6, 7, 8, 2, 1, 1, 1, 6, 7, 73, 3, 6 };
            List<int[]> repeatedArrays = new List<int[]>();
            List<int> tempNumbers = new List<int>();
            bool firstAdd = true;
            int count = 0;
            int max = 0;
            int arrNumber = 0;

            for (int i = 0; i < arr.Count() - 1; i++)
            {

                if (arr[i] == arr[i + 1] - 1)
                {
                    if (firstAdd)
                    {
                        tempNumbers.Add(arr[i]);
                        firstAdd = false;
                    }
                    tempNumbers.Add(arr[i + 1]);
                }
                else
                {
                    firstAdd = true;
                    if (tempNumbers.Count > 1)
                    {
                        repeatedArrays.Add(tempNumbers.ToArray());
                        tempNumbers.Clear();
                    }
                    tempNumbers.Clear();
                }
            }

            foreach (var item in repeatedArrays)
            {
                foreach (var item2 in item)
                    count++;
                if (count > max)
                {
                    max = count;
                    arrNumber = repeatedArrays.IndexOf(item);
                }
                count = 0;
            }

            foreach (var item in repeatedArrays[arrNumber])
            {
                Console.Write(item + " ");
            }
        }
    }
}
