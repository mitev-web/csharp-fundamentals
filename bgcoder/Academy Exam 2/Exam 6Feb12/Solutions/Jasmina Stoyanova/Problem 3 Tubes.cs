
using System;

namespace Task03
{

    class Tubes
    {

        static void Main(string[] args)
        {
            short n = Int16.Parse(Console.ReadLine());
            int m = Int32.Parse(Console.ReadLine());
            int[] tubes = new int[n];
            int countTubes = 0;
            long sumTubes = 0L;
            int avgSumTubes;
            bool isPossible = false;

            for (int i = 0; i < n; i++)
            {
                tubes[i] = Int32.Parse(Console.ReadLine());
                sumTubes = sumTubes + tubes[i];
            }

            avgSumTubes = (int)(sumTubes / m);

            for (int i = avgSumTubes; i > 0; i--)
            {
                for (int j = 0; j < tubes.Length; j++)
                {
                    countTubes =(int)(countTubes + tubes[j] / i);
                }

                if (countTubes == m)
                {
                    isPossible = true;
                    Console.WriteLine(i);
                    break;
                }

                countTubes = 0;
            }

            if (isPossible == false)
            {
                Console.WriteLine(-1);
            }
        }
    }
}