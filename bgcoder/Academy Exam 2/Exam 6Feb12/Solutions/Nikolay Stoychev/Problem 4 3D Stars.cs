using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _3dStars
{
    class Program
    {
        static int width;
        static int height;
        static int depth;
        static char[, ,] cuboid;
        static Dictionary<char, int> stars = new Dictionary<char, int>();

        private static void ReadCuboid()
        {
            // Read the cuboid size
            //StreamReader reader = new StreamReader("in.txt");
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
                    string[] colors = sequences[d].Split();
                    for (int w = 0; w < width; w++)
                    {
                        char cubeColor = colors[0][w];
                        cuboid[w, h, d] = cubeColor;
                    }
                }
            }
            //reader.Close();
        }

        private static void PrintResult()
        {
            if (stars.Count != 0)
            {
                int starsCount = 0;
                foreach (var star in stars)
                {
                    starsCount += star.Value;
                }

                Console.WriteLine(starsCount);

                List<char> keys = new List<char>(stars.Keys);
                keys.Sort();

                foreach (var key in keys)
                {
                    Console.WriteLine(key + " " + stars[key]);
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }

        static void CheckForStar(int w, int h, int d)
        {
            char color = cuboid[w,h,d];
            if (cuboid[w, h, d + 1] == color && cuboid[w, h, d + 2] == color && cuboid[w, h - 1, d + 1] == color &&
                cuboid[w, h + 1, d + 1] == color && cuboid[w - 1, h, d + 1] == color && cuboid[w + 1, h, d + 1] == color)
            {
                if (stars.ContainsKey(color))
                {
                    stars[color]++;
                }
                else 
                {
                    stars.Add(color, 1);
                }
            }
        }

        static void Main()
        {
            ReadCuboid();

            for (int d = 0; d < depth - 2; d++)
            {
                for (int h = 1; h < height - 1; h++)
                {
                    for (int w = 1; w < width - 1; w++)
                    {
                        CheckForStar(w, h, d);
                    }
                }
            }

            PrintResult();
        }
    }
}