using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4___3d_stars
{
    class Program
    {
        static int width, height, depth;
        static char[, ,] cuboid;
        static Dictionary<char, int> Stars = new Dictionary<char, int>();

        static void Main()
        {
            // Read the cuboid size
            ReadCuboid();

            // Find the star
            FindStar();

            int sum = 0;
            foreach (var val in Stars)
            {
                sum += val.Value;
            }
            Console.WriteLine(sum);
            Stars = Stars.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var star in Stars)
            {
                Console.WriteLine("{0} {1}",star.Key,star.Value);
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

        private static void FindStar()
        {
            for (int startW = 1; startW < width-1; startW++)
            {
                for (int startH = 1; startH < height-1; startH++)
                {
                    for (int startD = 1; startD < depth-1; startD++)
                    {
                        if (IsStar(startW, startH, startD))
                        {
                            if (Stars.ContainsKey(cuboid[startW, startH, startD]))
                            {
                                Stars[cuboid[startW, startH, startD]]++;
                            }
                            else
                                Stars.Add(cuboid[startW, startH, startD], 1);
                        }
                    }
                }
            }
        }
        private static bool IsStar(int w, int h, int d)
        {
            if (cuboid[w, h, d] == cuboid[w + 1, h, d] && cuboid[w, h, d] == cuboid[w - 1, h, d] &&
                    cuboid[w, h, d] == cuboid[w, h + 1, d] && cuboid[w, h, d] == cuboid[w, h - 1, d] &&
                        cuboid[w, h, d] == cuboid[w, h, d + 1] && cuboid[w,h,d] == cuboid[w, h, d - 1])
            {
                return true;
            }
            else return false;
        }
    }
}
