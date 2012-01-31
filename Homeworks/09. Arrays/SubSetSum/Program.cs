using System;
using System.Linq;

namespace Task16
{
    class Program
    {
        static void Main(string[] args)
        {
            //* We are given an array of integers and a number S. 
            //Write a program to find if there exists a subset of the elements of the 
            //array that has a sum S. Example:
            //    arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14  yes (1+2+5+6)
            int S = 45;

            int[] numbers = { 1, 2, 4,  7};
            int result = FindSubSets(numbers, S);
            Console.WriteLine(result);

            if (result > 0)
            {
                Console.WriteLine("The sum of these numbers: ");
                bool firstFound = true;
                for (int i = 0; i < numbers.Length; i++)
                {
                    if ((result & (1 << i)) != 0)
                    {
                        if (firstFound)
                        {
                            firstFound = false;
                            Console.Write("{0}", numbers[i]);
                        }
                        else
                        {
                            Console.Write(" {0}", numbers[i]);
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

        static int FindSubSets(int[] numbers, int S)
        {
            for (int i = 1; i < (1 << numbers.Length); i++)
            {
                int sum = 0;
                for (int j = 0; j < numbers.Length; j++)
                {
                    if ((i & (1 << j)) != 0)
                    {
                        sum += numbers[j];
                    }
                }
                if (sum == S)
                {
                    return i;
                }
            }
            return 0;
        }
    }
}