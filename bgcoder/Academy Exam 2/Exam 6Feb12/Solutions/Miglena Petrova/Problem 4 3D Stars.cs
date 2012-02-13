using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam2_Zad4
{
    class Program
    {
        static byte width, height, depth;
        static char[, ,] cuboid;

        //static int lineMaxLen = 0;
        static int starsCount;

        static void Main(string[] args)
        {
            // Read the cuboid size
            ReadCuboid();

            for (byte h = 0; h < height - 2; h++)
            {
                for (byte d = 0; d < depth - 2; d++)
                {
                    for (byte w = 0; w < width - 2; w++)
                    {
                        if (cuboid[h+1,d+1,w+1] == cuboid[h+1, d+1, w] && cuboid[h+1,d+1,w+1] == cuboid[h+1, d+1, w +2] 
                               && cuboid[h+1,d+1,w+1] == cuboid[h+1, d, w+1] && cuboid[h+1,d+1,w+1] == cuboid[h+1, d + 2, w+1] 
                               && cuboid[h+1,d+1,w+1] == cuboid[h, d+1, w+1] && cuboid[h+1,d+1,w+1] == cuboid[h, d+1, w+1])
                        {
                            starsCount++;

                        }
                    }
                }
            }
            Console.WriteLine(starsCount);
        }
        private static void ReadCuboid()
        {
            // Read the cuboid size
            string cuboidSize = Console.ReadLine();
            string[] sizes = cuboidSize.Split();
            width = byte.Parse(sizes[0]);
            height = byte.Parse(sizes[1]);
            depth = byte.Parse(sizes[2]);
            cuboid = new char[width, height, depth];

            // Read the cuboid data
            for (byte h = 0; h < height; h++)
            {
                string line = Console.ReadLine();
                string[] letters = line.Split();
                for (byte d = 0; d < depth; d++)
                {
                    for (byte w = 0; w < width; w++)
                    {
                        cuboid[w, h, d] = letters[d][w];
                    }
                }
            }
        }

    }
}
