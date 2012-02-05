using System;
using System.Linq;

namespace K_CustomSubSetFromN
{
    class Program
    {
        public static void Main()
        {
            int n = 3;
            int k = 2;
            int startIndex = 0;
            int startNumber = 1;
            int maxNumber = n;
            int[] vector = new int[k];

            GenerateCombinationsWithDuplicates(startIndex, k,
                startNumber, maxNumber, vector);
        }
 
        public static void GenerateCombinationsWithDuplicates(
            int index, int endIndex, int startNumber, int maxNumber, int[] vector)
        {
            if (index == endIndex)
            {
                PrintVector(vector);
            }
            else
            {
                for (int number = startNumber; number <= maxNumber; number++)
                {
                    vector[index] = number;
                    GenerateCombinationsWithDuplicates(
                        index + 1, endIndex, number, maxNumber, vector);
                }
            }
        }
 
        public static void PrintVector(int[] vector)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                Console.Write(vector[i]);
            }
            Console.WriteLine();
        }
    }
}