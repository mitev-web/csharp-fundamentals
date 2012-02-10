using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 10;


            int[] rgNum = new int[100];
            int i;

            /* create a workspace of numbers in their respective places */
            for (i = 1; i <= N; i++)
            {
                rgNum[i] = i;
            }
            GeneratePermutation(1, N, rgNum);
        }
        static void GeneratePermutation(int k, int max, int[] nums)
        {
            int i, j, tmp;

            /* when k > n we are done and should print */
            if (k <= max)
            {
                for (i = k; i <= max; i++)
                {
                    tmp = nums[i];
                    for (j = i; j > k; j--)
                    {
                        nums[j] = nums[j - 1];
                    }
                    nums[k] = tmp;

                    /* recurse on k+1 to n */
                    GeneratePermutation(k + 1, max, nums);

                    for (j = k; j < i; j++)
                    {
                        nums[j] = nums[j + 1];
                    }
                    nums[i] = tmp;
                }
            }
            else
            {

                for (i = 1; i <= max; i++)
                {

                        Console.Write(nums[i] - 1+" ");
              

             
                }
                Console.WriteLine();
            }
        }
    }
}
