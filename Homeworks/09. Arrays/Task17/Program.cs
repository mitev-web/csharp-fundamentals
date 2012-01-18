using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task17
{
    class Program
    {
        static void Main(string[] args)
        {
            //* Write a program that reads three integer numbers N, K and S and 
            //an array of N elements from the console. Find in the array a subset 
            //of K elements that have sum S or indicate about its absence.

            int[] arr = { 4,25,2,56,-7,32,3,3,1,2,7,8,17,0,1};

            int K = int.Parse(Console.ReadLine());

            int S = int.Parse(Console.ReadLine());

            int result = FindSubSets(arr, S, K);


            if (result > 0)
            {
                Console.WriteLine("The sum of these numbers: ");
                bool firstFound = true;
                for (int i = 0; i < arr.Length; i++)
                {
                    if ((result & (1 << i)) != 0)
                    {
                        if (firstFound)
                        {
                            firstFound = false;
                            Console.Write("{0}", arr[i]);
                        }
                        else
                        {
                            Console.Write(" {0}", arr[i]);
                        }
                    }
                }
                Console.WriteLine(" is a subset");
            }
            else
            {
                Console.WriteLine("There are no zero subsets");
            }

        }


        static int FindSubSets(int[] numbers, int S, int K)
        {
            List<int> sumNumbs = new List<int>();
            for (int i = 1; i < (1 << numbers.Length); i++)
            {
                int sum = 0;

                sumNumbs.Clear();
                for (int j = 0; j < numbers.Length; j++)
                {
                    if ((i & (1 << j)) != 0)
                    {
                        if(sumNumbs.Count < K)
                        sumNumbs.Add(numbers[j]);
                    }
                }
                if (sumNumbs.Count == K && sumNumbs.Sum() == S)
                {
                    return i;
                }
            }
            return 0;
        }
    }
}
