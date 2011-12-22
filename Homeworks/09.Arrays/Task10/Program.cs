using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task10
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that finds in given array of integers a sequence 
            //of given sum S (if present). Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11  {4, 2, 5}	

            int S = int.Parse(Console.ReadLine());

            int[] numbers = { 7, 2, 63, 7, 5, 5, 5, 5, -20, 7, 2, 2, 6, 7, 8, 7, 1, 20, 1, 1, 6, 3, 7, 7, 3, 1 };
            int result = FindSubSets(numbers, S);


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
