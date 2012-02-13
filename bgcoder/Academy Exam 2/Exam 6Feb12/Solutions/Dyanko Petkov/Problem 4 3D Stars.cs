using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3D_task
{
    class Program
    {
        public static int W = 0;
        public static int H = 0;
        public static int D = 0;
        public static char[, ,] cuboid;
        static bool[, ,] visited;

        private static long CalculateWalkSum()
        {
            int width = W / 2;
            int height = H / 2;
            int depth = D / 2;
            bool finished = false;
            long sum = cuboid[width, height, depth];
            visited = new bool[width, height, depth];
            while (!finished)
            {
                visited[width, height, depth] = true;

                int newW, newH, newD, maxCount;
                GetNextPosition(width, height, depth, out newW, out newH, out newD, out maxCount);

                if (visited[newW, newH, newD] || maxCount > 1)
                {
                    // We fall into a loop (went into already visited position)
                    finished = true;
                }
                else
                {
                    sum = sum + cuboid[newW, newH, newD];
                    width = newW;
                    height = newH;
                    depth = newD;
                }
            }
            return sum;
        }

        private static void GetNextPosition(int w, int h, int d,
            out int newW, out int newH, out int newD, out int maxCount)
        {
            char maxValue = char.MinValue;
            newW = 0;
            newH = 0;
            newD = 0;
            maxCount = 0;

            char oldCurrentPositionValue = cuboid[w, h, d];
            cuboid[w, h, d] = char.MinValue;

            // Check the left / right directions
            for (int nextW = 0; nextW < w; nextW++)
            {
                char value = cuboid[nextW, h, d];
                if (value == maxValue)
                {
                    maxCount++;
                }
                if (value > maxValue)
                {
                    maxValue = value;
                    newW = nextW;
                    newH = h;
                    newD = d;
                    maxCount = 1;
                }
            }
        }

        public static void ReadCuboid()
        {
            string firstLine = Console.ReadLine();
            string[] firstLineArr = firstLine.Split(' ');
            W = int.Parse(firstLineArr[0]);
            H = int.Parse(firstLineArr[1]);
            D = int.Parse(firstLineArr[2]);

            cuboid = new char[W, H, D];

            for (int h = 0; h < H; h++)
            {
                string line = Console.ReadLine();
                string[] sequences = line.Split(' ');

                for (int d = 0; d < D; d++)
                {
                    string[] letters = sequences[d].Split(' ');

                    for (int w = 0; w < W; w++)
                    {
                        char[] cube = letters[w].ToCharArray();
                        cuboid[w, h, d] = cube[w];
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            ReadCuboid();
        }
    }
}
