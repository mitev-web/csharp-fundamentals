using System;
using System.Linq;

namespace _03.Tubes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int wholeLength = 0, min=Int32.MaxValue;
            int newTubesCounter = 0;
            int[] remainings = new int[n];

            int[] tubes = new int[n];
            for (int i = 0; i < n; i++)
            {
                tubes[i] = int.Parse(Console.ReadLine());
                wholeLength += tubes[i];
                if (min>tubes[i])
                {
                    min = tubes[i];
                }
            }

            int maxSize = wholeLength / m;

            if (maxSize>min)
            {
                maxSize = min;
            }
            while (newTubesCounter<m)
            {
                newTubesCounter = 0;
                for (int i = 0; i < tubes.Length; i++)
                {
                    newTubesCounter += tubes[i] / maxSize;
                    remainings[i] = tubes[i] % maxSize;
                }
                if (maxSize<min/m)
                {
                    Console.WriteLine(-1);
                    return;
                }
                maxSize--;

            }
            maxSize++;
            if (maxSize >= 2 * min)
            {
                Console.WriteLine(-1);
                return;
            }
              Console.WriteLine(maxSize);

        }
    }
}
