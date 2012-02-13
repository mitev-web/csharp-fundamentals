using System;
using System.Diagnostics;

namespace adc
{
    public class Permu
    {
        static void permut(int k, int n, int[] nums)
        {
            int i, j, tmp;

            /* when k > n we are done and should print */
            if (k <= n)
            {

                for (i = k; i <= n; i++)
                {
                    tmp = nums[i];
                    for (j = i; j > k; j--)
                    {
                        nums[j] = nums[j - 1];
                    }
                    nums[k] = tmp;

                    /* recurse on k+1 to n */
                    permut(k + 1, n, nums);

                    for (j = k; j < i; j++)
                    {
                        nums[j] = nums[j + 1];
                    }
                    nums[i] = tmp;
                }
            }
            else
            {
                //for (i = 1; i <= n; i++)
                //{
                //    Console.Write("{0} ", nums[i]-1);
                //}
                //Console.WriteLine();
            }
        }

        static void Main()
        {

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int iCount;
            int[] rgNum = new int[100];
            int i;


            iCount = 8;

            /* create a workspace of numbers in their respective places */
            for (i = 1; i <= iCount; i++)
            {
                rgNum[i] = i;
            }

           
            permut(1, iCount, rgNum);
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine(elapsedTime, "RunTime");
        }

    }
}