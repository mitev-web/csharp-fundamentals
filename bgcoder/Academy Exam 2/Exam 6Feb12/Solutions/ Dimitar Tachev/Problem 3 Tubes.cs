using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Task3
{
    class Program
    {
        static int numberOfTubes = 0;
        static int numberOfParts = 0;
        static int maxLength = 0;
        static int[] tubeSizes;
        static bool SOLVED = false;
        static int resultLength = 0;
        static void Main(string[] args)
        {
            ReadInput();
            CountMaxLength();
            Solve(maxLength);
            if (resultLength > 0)
            {
                Console.WriteLine(resultLength);
            }
            else
            {
                Console.WriteLine(-1);
            }
        }

        private static void CountMaxLength()
        {
            BigInteger sum = 0;
            for (int i = 0; i < tubeSizes.Length; i++)
            {
                sum += tubeSizes[i];
            }
            maxLength = (int)(sum / numberOfParts);
        }
        private static void Solve(int currLength)
        {
            while (!SOLVED && currLength > 0)
            {
                int nextLength = int.MinValue;
                {
                    int tempTubes = 0;
                    for (int i = 0; i < tubeSizes.Length; i++)
                    {
                        tempTubes += tubeSizes[i] / currLength;
                        if (tubeSizes[i] / (tubeSizes[i] / currLength + 1) > nextLength && tubeSizes[i] / (tubeSizes[i] / currLength + 1)<currLength)
                        {

                            nextLength = tubeSizes[i] / (tubeSizes[i] / currLength + 1);
                        }
                    }
                    if (tempTubes >= numberOfParts)
                    {
                        SOLVED = true;
                        resultLength = currLength;
                        return;
                    }
                    currLength = nextLength;
                }
            }
        }
        private static void ReadInput()
        {
            numberOfTubes = int.Parse(Console.ReadLine());
            numberOfParts = int.Parse(Console.ReadLine());
            tubeSizes = new int[numberOfTubes];
            for (int i = 0; i < numberOfTubes; i++)
            {
                tubeSizes[i] = int.Parse(Console.ReadLine());
            }
        }
    }
}

/*
4
11
803
777
444
555
*/

/*
3
6
100
200
300
*/