using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubSetStrings
{
    class SubSetString
    {
        public static string[] words = { "FIRE", "ACID", "CENG", "EDGE", "FACE", "ICED", "RING", "CERN" };
        // public static int K = 4;

        //Write a program for generating and 
        //printing all subsets of k strings from given set of strings.
        //Example: s = {test, rock, fun}, k=2
        //(test rock),  (test fun),  (rock fun)

        static void Main(string[] args)
        {
            int[] arr = new int[words.Count()];
            GenerateVariations(arr, 0, words.Length - 1);
        }

        public static void GenerateVariations(int[] arr, int startIndex, int endIndex)
        {
            if (startIndex >= arr.Length)
            {
                //if (arr.Distinct().Count() == words.Count())
                //{
                	
                //}
                   // PrintVariation(arr);
            }
            else
            {
                for (int i = 0; i <= endIndex; i++)
                {
                    arr[startIndex] = i;
                    GenerateVariations(arr, startIndex + 1, endIndex);
                }
            }
        }

        private static void PrintVariation(int[] arr)
        {

            foreach (var item in arr)
            {
                Console.Write(" {0} ", words[item]);
            }
            Console.WriteLine();
            Console.WriteLine();

        }
    }
}