using System;
using System.Linq;

namespace Problem3
{
    class Tubes
    {
        static void Main(string[] args)
        {
            short n = short.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int[] tubeSizes = new int[n];

            long sumTubeLength = 0;
            for (int i = 0; i < tubeSizes.Length; i++)
            {
                tubeSizes[i] = int.Parse(Console.ReadLine());
                sumTubeLength += tubeSizes[i];
            }

            for (long i = sumTubeLength / m; i > 0; i--)
            {
                long sumParts = 0;
                for (int j = 0; j < tubeSizes.Length; j++)
                {
                    sumParts += tubeSizes[j] / i;
                }
                if (sumParts >= m)
                {
                    Console.WriteLine(i);
                    break;
                }
            }
        }
    }
}