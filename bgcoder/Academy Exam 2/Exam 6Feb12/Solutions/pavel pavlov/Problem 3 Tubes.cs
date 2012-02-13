using System;

namespace Pipes
{
    class Program
    {
        static void Main()
        {
            int tubes = int.Parse(Console.ReadLine());
            int neededTubes = int.Parse(Console.ReadLine());
            int[] sizeOfTubes = new int[tubes];
            int sizeOfTube = 0;
            for (int i = 0; i < sizeOfTubes.Length; i++)
            {
                sizeOfTubes[i] = int.Parse(Console.ReadLine());
            }
            int maxSizeOfTubes = 0;

            for (int i = 0; i < sizeOfTubes.Length; i++)
            {
                maxSizeOfTubes += sizeOfTubes[i];
            }
            //int tubes = 4;
            //int neededTubes = 11;
            //int[] sizeOfTubes = new int[] { 803, 777, 444, 555 };
            //int maxSizeOfTubes = 2579;

            int canCut = 0;
            int tempSize = maxSizeOfTubes / neededTubes;

            tempSize = FindMaximalSizeOfTube(neededTubes, tempSize, canCut, sizeOfTubes);
            Console.WriteLine(size + 1);
        }
        private static int size = 0;
        private static int FindMaximalSizeOfTube(int neededTubes, int tempSize, int canCut, int[] sizeOfTubes)
        {
            if (canCut == neededTubes)
            {
                size = tempSize;
                return tempSize;
            }

            canCut = 0;

            for (int i = 0; i < sizeOfTubes.Length; i++)
            {
                canCut += sizeOfTubes[i] / tempSize;
            }

            if (canCut <= neededTubes)
            {
                FindMaximalSizeOfTube(neededTubes, tempSize - 1, canCut, sizeOfTubes);
                return tempSize;
            }
            return tempSize;
        }
    }
}
