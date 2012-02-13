using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace _3___Tubes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] tubes = new int[n];
            int m = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                tubes[i] = int.Parse(Console.ReadLine());
            }
            BigInteger sum = 0;
            for (int i = 0; i < tubes.Length; i++)
            {
                sum += tubes[i];
            }
            int min = tubes.Min();
            int tempSize = (int)(sum / m);
            for (int i = tempSize; i > 0; i--)
            {
                int numOfTubes = 0;
                for (int j = 0; j < n; j++)
                {
                    numOfTubes += tubes[j] / i;
                }
                if (numOfTubes == m)
                {
                    tempSize = i;
                    break;
                }
            }
            Console.WriteLine(tempSize);
        }
    }
}
