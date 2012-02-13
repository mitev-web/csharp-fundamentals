using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task3Tubes
{
    class Program
    {
        static int N, M;
        static long[] tubes;

        static void Main(string[] args)
        {
            Input();
            
            decimal sum = tubes.Sum();
            decimal maxSize = sum / M;
            long max = (long)maxSize;

            long tubesCount = Calculate(max);
            while (tubesCount != M)
            {
                max--;
                tubesCount = Calculate(max);
            }
            Console.WriteLine(max);
        }

        static void Input()
        {
            N = int.Parse(Console.ReadLine());
            M = int.Parse(Console.ReadLine());
            tubes = new long[N];
            for (int i = 0; i < N; i++)
            {
                tubes[i] = long.Parse(Console.ReadLine());
            }
        }

        static long Calculate(long tubeSize)
        {
            long bestSum = 0;
            for (int i = 0; i < tubes.Length; i++)
            {
                bestSum += tubes[i] / tubeSize;
            }
            return bestSum;
        }
    }
}
