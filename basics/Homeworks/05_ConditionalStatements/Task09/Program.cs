using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task09
{
    class Program
    {
        static void Main(string[] args)
        {
            //We are given 5 integer numbers.
            //Write a program that checks if the sum of some subset of them is 0. 
            //Example: 3, -2, 1, 1, 8  1+1-2=0.
        int N = 9;
        int[] numbers = new int[N];

        for (int i = 0; i < N; i++)
        {
            Console.Write("Enter number {0}: ", i);
            string line = Console.ReadLine();
            numbers[i] = int.Parse(line);
        }

        int result = FindZeroSubsets(numbers);
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
            Console.WriteLine(" is zero!");
        }
        else
        {
            Console.WriteLine("There are no zero subsets");
        }
    }

    static int FindZeroSubsets(int[] numbers)
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
            if (sum == 0)
            {
                return i;
            }
        }
        return 0;
    }
    }
}
