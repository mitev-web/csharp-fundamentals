using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3DStars
{
    class Program
    {
        static int width, height, depth;
        static char[, ,] cuboid;
        static int starsCount = 0;

        static void Main(string[] args)
        {
            // Read the cuboid size
            ReadCuboid();

            List<char> colors = new List<char>();

            for (int startW = 1; startW < width - 1; startW++)
            {
                for (int startH = 1; startH < height - 1; startH++)
                {
                    for (int startD = 1; startD < depth - 1; startD++)
                    {
                        char color = cuboid[startW, startH, startD];
                        if (color == cuboid[startW - 1, startH, startD] && color == cuboid[startW + 1, startH, startD] &&
                            color == cuboid[startW, startH - 1, startD] && color == cuboid[startW, startH + 1, startD] &&
                            color == cuboid[startW, startH, startD - 1] && color == cuboid[startW, startH, startD + 1])
                        {
                            starsCount++;
                            colors.Add(color);
                        }
                    }
                }
            }
            colors.Sort();
            Console.WriteLine(starsCount);
            
            /*StringBuilder almost = new StringBuilder();
            List<string> result = new List<string>();
            for (char i = 'A'; i < 'Z'; i++)
            {
                int tempCounter = 0;
                for (int j = 0; j <= colors.Count; j++)
                {
                    if (colors[j] == i)
                    {
                        tempCounter++;
                    }   
                }
                if (tempCounter != 0)
	            {
		            almost.Append(i);
                    almost.Append(' ');
                    almost.Append(tempCounter);
                    result.Add(almost.ToString());
                    almost.Clear();
	            }
               
            }*/

            
            var g = colors.GroupBy(i => i);

            foreach (var grp in g)
            {
                Console.WriteLine("{0} {1}", grp.Key, grp.Count());
            }

            /*foreach (string item in result)
            {
                Console.WriteLine(item);
            }*/
            
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