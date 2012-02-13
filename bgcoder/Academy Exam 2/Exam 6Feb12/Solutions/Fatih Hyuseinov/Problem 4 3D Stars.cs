using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04
{
    class Program
    {
        static int width, height, depth;
        static char[, ,] cuboid;
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
        static void Main(string[] args)
        {
            ReadCuboid();





            int counter = 0;
            List<char> colors = new List<char>();
            List<int> colorCounter = new List<int>();

            char col = ' ';
            bool existColor = false;
            int index = 0;

            for (int i = 1; i < cuboid.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < cuboid.GetLength(1) - 1; j++)
                {
                    for (int p = 1; p < cuboid.GetLength(2) - 1; p++)
                    {
                        if (cuboid[i, j, p] == cuboid[i + 1, j, p] && cuboid[i, j, p] == cuboid[i, j + 1, p] && cuboid[i, j, p] == cuboid[i, j, p + 1] && cuboid[i, j, p] == cuboid[i - 1, j, p] && cuboid[i, j, p] == cuboid[i, j - 1, p] && cuboid[i, j, p] == cuboid[i, j, p - 1])
                        {
                            existColor = false;
                            counter++;
                            col = cuboid[i, j, p];
                            for (int c = 0; c < colors.Count; c++)
                            {
                                if (col == colors[c])
                                {
                                    existColor = true;
                                    index = c;
                                    break;
                                }
                            }
                            if (!existColor)
                            {
                                colors.Add(col);
                                colorCounter.Add(1);
                            }
                            else if (existColor)
                            {

                                colorCounter[index]++;
                            }
                        }
                    }

                }
            }
            Console.WriteLine(counter);

            for (int i = 0; i < colors.Count; i++)
            {
                for (int j = 0; j < colors.Count; j++)
                {
                    if (i != j && colors[i] > colors[j])
                    {
                        char swap = colors[i];
                        colors[i] = colors[j];
                        colors[j] = swap;

                        int indexSwap = colorCounter[i];
                        colorCounter[i] = colorCounter[j];
                        colorCounter[j] = indexSwap;
                    }
                }
            }



            if (colors.Count != 0)
            {
                for (int i = 0; i < colors.Count; i++)
                {
                    Console.WriteLine("{0} {1} ", colors[i], colorCounter[i]);

                }
            }

        }
    }
}
