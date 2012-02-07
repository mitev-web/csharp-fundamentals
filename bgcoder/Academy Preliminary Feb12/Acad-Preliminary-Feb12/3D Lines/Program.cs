using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    class Program
    {
        static int width, height, depth;
        static char[, ,] cuboid;

        static int lineMaxLen = 0;
        static int linesCount;
        static bool[, , , , ,] processed;

    static void Main(string[] args)
    {
        ReadCuboid();
        StringBuilder sb = new StringBuilder();
  
        PrintCuboid();


  
       
    }

        static void PrintCuboid()
        {
            for (int h = 0; h < height; h++)
            {
                for (int d = 0; d < depth; d++)
                {
                    for (int w = 0; w < width; w++)
                    {
                        Console.Write(cuboid[w, h, d]);
                    }
                    Console.Write(" ");
                }
                Console.WriteLine();
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

