using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LongestEqualSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a method that finds the longest 
            //subsequence of equal numbers in given List<int>
            //and returns the result as new List<int>. Write a program 
            //to test whether the method works correctly.
            List<int> numbers = new List<int> { 3, 3, 5, 3, 4, 5, 7, 7, 7, 2, 345, 2, 2, 5 };

            foreach (var item in LongestEqualSubseq(numbers))
            {
                Console.WriteLine(item);
            }
        }

        public static List<int> LongestEqualSubseq(List<int> numbers)
        {
            int currentSeq = 0;
            int maxSeq = 0;
            int maxSeqNum = 0;
            int seqNumber = 0;



            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] == numbers[i - 1])
                {
                    if (numbers[i] == seqNumber)
                    {
                        currentSeq++;
                        if (currentSeq > maxSeq)
                        {
                            maxSeq = currentSeq;
                            maxSeqNum = numbers[i];
                        }
                    }
                    else
                    {
                        seqNumber = numbers[i];
                        currentSeq = 2;
                    }
                }
            }
            List<int> result = new List<int>();
            for (int i = 0; i < maxSeq; i++)
            {
                result.Add(maxSeqNum);
            }

            return result;
        }
    }
}