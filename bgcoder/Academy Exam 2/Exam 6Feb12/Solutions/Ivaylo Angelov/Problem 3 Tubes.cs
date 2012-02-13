using System;
 
namespace ProblemThree
{
    class ProblemThree
    {
        static long biggestPossible(int neededTubes, int[] sizes, long sizesSum)
        {
            long bestSoFar = sizesSum / neededTubes;
            long vinkelCounter = 0;
            bool answerFound = false;
            while (answerFound == false)
            {
                for (int j = 0; j < sizes.Length; j++)
                {
                    if (sizes[j] < bestSoFar)
                    {
                        continue;
                    }
                    else
                    {
                        long remainder = sizes[j] % bestSoFar;
                        long diff = sizes[j] - remainder;
                        long tubesWeCanGet = diff / bestSoFar;
                        vinkelCounter += tubesWeCanGet;
                    }
                }
 
                if (vinkelCounter >= neededTubes)
                {
                    answerFound = true;
                }
 
                else
                {
                    vinkelCounter = 0;
                    bestSoFar--;
                }
            }
            return bestSoFar;
        }
 
        static void Main()
        {
            short tubes = short.Parse(Console.ReadLine());
            int needed = int.Parse(Console.ReadLine());
            int[] tubeSizes = new int[tubes];
            long sum = 0;
            for (long i = 0; i < tubeSizes.Length; i++)
            {
                tubeSizes[i] = int.Parse(Console.ReadLine());
                sum += tubeSizes[i];
            }
 
            if (sum < needed)
            {
                Console.WriteLine(-1);
            }
 
            else if (sum % needed == 0)
            {
                Console.WriteLine(sum / needed);
            }
 
            else
            {
                long bestSize = biggestPossible(needed, tubeSizes, sum);
                Console.WriteLine(bestSize);
            }
        }
    }
}