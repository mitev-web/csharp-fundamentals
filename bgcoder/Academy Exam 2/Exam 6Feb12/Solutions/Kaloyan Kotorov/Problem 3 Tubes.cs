using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tubes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long m = long.Parse(Console.ReadLine());
            long[] tubes = new long[n];

            for (int i = 0; i < n; i++)
            {
                tubes[i] = long.Parse(Console.ReadLine());
            }

            long minTube = tubes.Sum() / m;
            long[] parts = new long[n];
            
            while (minTube > 0)
            {
                for (int i = 0; i < n; i++)
                {
                    parts[i] = tubes[i] / minTube;
                }
                if (m == parts.Sum())
                {
                    Console.WriteLine(minTube);
                    break;
                }
                else
                {
                    minTube--;
                }
            }
            if (minTube == 0)
            {
                Console.WriteLine("-1");
            }
        }
    }
}