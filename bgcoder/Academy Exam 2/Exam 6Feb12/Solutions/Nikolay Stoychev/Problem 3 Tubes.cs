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
            int tubesCount = int.Parse(Console.ReadLine());
            int fightersCount = int.Parse(Console.ReadLine());
            int[] tubes = new int[tubesCount];
            for (int i = 0; i < tubesCount; i++)
            {
                tubes[i] = int.Parse(Console.ReadLine());
            }

            int biggestTube = int.MinValue;
            foreach (var tube in tubes)
            {
                if (tube > biggestTube)
                {
                    biggestTube = tube;
                }
            }

            int result = -1;

            int checkedSize = biggestTube;

            while (checkedSize > 0)
            {
                int currentTubesCount = 0;
                foreach (int tube in tubes)
                {
                    currentTubesCount += tube / checkedSize;
                }

                if (currentTubesCount > fightersCount)
                {
                    break;
                }

                if (currentTubesCount == fightersCount)
                {
                    result = checkedSize;
                    break;
                }

                if (currentTubesCount * 2 < fightersCount)
                {
                    checkedSize -= 2;
                }
                else
                {
                    checkedSize--;
                }
            }
            Console.WriteLine(result);
        }
    }
}