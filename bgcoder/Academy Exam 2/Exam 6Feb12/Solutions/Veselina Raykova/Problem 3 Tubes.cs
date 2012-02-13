using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.Tubes_v6
{
    class Program
    {
        static void Main (string[] args)
        {
            int n = int.Parse (Console.ReadLine ());
            int m = int.Parse (Console.ReadLine ());
            int[] tubes = new int[n];

            int tubesNeed = 0;
            int size = 0;
            int count = 0;
            long sum = 0;

            for (int i = 0; i < n; i++)
            {
                tubes[i] = int.Parse (Console.ReadLine ());
                sum += tubes[i];
            }

            if (sum / m < 1)
            {
                Console.WriteLine ("-1");
                return;
            }

            for (int i = 0; tubesNeed < m; i++)
            {
                tubesNeed = 0;
                size = (int)(sum / m) - i; //100-1=100
                for (int j = 0; j < n; j++)
                {
                    count = tubes[j] / size; //100:50 = 2
                    tubesNeed += count;
                }
            }
            Console.WriteLine (size);

        }
    }
}
