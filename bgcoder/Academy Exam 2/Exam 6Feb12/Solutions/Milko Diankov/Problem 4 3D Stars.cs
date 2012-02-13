using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T4._3D_Stars
{
    class Program
    {
        static int width, height, depth;
        static char[, ,] cuboid;

        static void Main(string[] args)
        {
            ReadCuboid();
            List<char> color = new List<char>();

            for (int startW = 1; startW < width - 1; startW++)
            {
                for (int startH = 1; startH < height - 1; startH++)
                {
                    for (int startD = 1; startD < depth - 1; startD++)
                    {
                        if (cuboid[startW, startH, startD] == cuboid[startW + 1, startH, startD] &&
                            cuboid[startW, startH, startD] == cuboid[startW - 1, startH, startD] &&

                            cuboid[startW, startH, startD] == cuboid[startW, startH + 1, startD] &&
                            cuboid[startW, startH, startD] == cuboid[startW, startH - 1, startD] &&

                            cuboid[startW, startH, startD] == cuboid[startW, startH, startD - 1] &&
                            cuboid[startW, startH, startD] == cuboid[startW, startH, startD + 1]
                            )
                        {
                            color.Add(cuboid[startW, startH, startD]);
                        }
                    }
                }
            }
            if (color.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                color.Sort();
                List<char> colorChar = new List<char>();
                List<int> colorCount = new List<int>();
                Console.WriteLine(color.Count());

                colorChar.Add(color[0]);
                colorCount.Add(1);
                int p = 0;
                for (int i = 1; i < color.Count; i++)
                {
                    if (color[i] != color[i - 1])
                    {
                        colorChar.Add(color[i]);
                        colorCount.Add(1);
                        p++;
                    }
                    else
                    {
                        colorCount[p]++;
                    }
                }
                for (int i = 0; i < colorChar.Count; i++)
                {
                    Console.WriteLine("{0} {1}", colorChar[i], colorCount[i]);
                }
            }
        }

        private static void ReadCuboid()
        {
            // Read the cuboid size
            string cuboidSize = Console.ReadLine();
            string[] sizes = cuboidSize.Split();
            width = int.Parse(sizes[0]);
            height = int.Parse(sizes[1]);
            depth = int.Parse(sizes[2]);
            cuboid = new char[width, height, depth];

            // Read the cuboid data
            for (int h = 0; h < height; h++)
            {
                string line = Console.ReadLine();
                string[] letters = line.Split();
                for (int d = 0; d < depth; d++)
                {
                    for (int w = 0; w < width; w++)
                    {
                        cuboid[w, h, d] = letters[d][w];
                    }
                }
            }
        }
    }
}