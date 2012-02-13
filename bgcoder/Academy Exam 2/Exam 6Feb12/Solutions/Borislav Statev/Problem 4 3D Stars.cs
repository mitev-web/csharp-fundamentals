using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4._3DStars
{
    class _3DStars
    {
        static char[, ,] cuboid;
        static int width;
        static int height;
        static int depth;

        static bool is3DStar(int w, int h, int d)
        {
            return (cuboid[w, h, d] == cuboid[w + 1, h, d] && cuboid[w, h, d] == cuboid[w - 1, h, d] &&
                cuboid[w, h, d] == cuboid[w, h + 1, d] && cuboid[w, h, d] == cuboid[w, h - 1, d] &&
                cuboid[w, h, d] == cuboid[w, h, d + 1] && cuboid[w, h, d] == cuboid[w, h, d - 1]);
        }

        static void Main(string[] args)
        {
            ReadCuboid();
            Dictionary<char, int> colorStarsCout = new Dictionary<char, int>();
            for (int w = 1; w < width - 1; w++)
            {
                for (int h = 1; h < height - 1; h++)
                {
                    for (int d = 1; d < depth - 1; d++)
                    {
                        if (is3DStar(w, h, d))
                        {
                            if (colorStarsCout.ContainsKey(cuboid[w, h, d]))
                            {
                                colorStarsCout[cuboid[w, h, d]]++;
                            }
                            else
                            {
                                colorStarsCout.Add(cuboid[w, h, d], 1);
                            }
                        }
                    }
                }
            }

            int coutAllStars = 0;
            foreach (var item in colorStarsCout)
            {
                coutAllStars += item.Value;
            }

            Console.WriteLine(coutAllStars);

            for (char i = 'A'; i <= 'Z'; i++)
            {
                if (colorStarsCout.ContainsKey(i))
                {
                    Console.WriteLine("{0} {1}",i,colorStarsCout[i]);
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

            // Read the cuboid content
            cuboid = new char[width, height, depth];
            for (int h = 0; h < height; h++)
            {
                string line = Console.ReadLine();
                string[] sequences = line.Split(' ');
                for (int d = 0; d < depth; d++)
                {

                    for (int w = 0; w < width; w++)
                    {
                        char cubeValue = sequences[d][w];
                        cuboid[w, h, d] = cubeValue;
                    }
                }
            }
        }
    }
}
