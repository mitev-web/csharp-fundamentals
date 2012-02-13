using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.Tubes
{
    class Tubes
    {

        static List<int> tubes;
        static int startTubes;
        static int neededTubes;
        static int finalCutedTubeSize;
        static int smallestTube;
        static int allTubesSize;

        static void Main(string[] args)
        {
            ReadInput();

            smallestTube = tubes.Min();

            // Calculate all sum
            foreach (var item in tubes)
                allTubesSize += item;

            for (int tubeSize = 1; tubeSize <= smallestTube; tubeSize++)
            {
                int currentCutedTubes = 0;
                List<int> tubesForCutting = new List<int>(tubes);
                for (int currentTubeIndex = 0; currentTubeIndex < tubesForCutting.Count; currentTubeIndex++)
                {
                    while (tubesForCutting[currentTubeIndex] >= tubeSize)
                    {
                        currentCutedTubes++;
                        tubesForCutting[currentTubeIndex] -= tubeSize;
                    }
                }

                if (currentCutedTubes == neededTubes)
                {
                    finalCutedTubeSize = tubeSize;
                }
            }

            // Write output
            Console.WriteLine(finalCutedTubeSize);
        }

        private static void ReadInput()
        {
            // Read input
            tubes = new List<int>();

            int.TryParse(Console.ReadLine(), out startTubes);
            int.TryParse(Console.ReadLine(), out neededTubes);

            for (int currentTube = 0; currentTube < startTubes; currentTube++)
            {
                int currentTubeSize;
                int.TryParse(Console.ReadLine(), out currentTubeSize);
                tubes.Add(currentTubeSize);
            }
        }
    }
}



