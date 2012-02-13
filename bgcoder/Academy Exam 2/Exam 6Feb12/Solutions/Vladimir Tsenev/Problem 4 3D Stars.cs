using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Task43DStars
{
    class Program
    {
        const string INPUT = @"..\..\input.txt";
        static int W, H, D;
        static char[, ,] cuboid;
        static SortedDictionary<char, int> stars = new SortedDictionary<char, int>();

        static void Main(string[] args)
        {
            Input();
            //InputFromFile();

            FindStars();

            PrintResult();
        }

        private static void InputFromFile()
        {
            using (StreamReader reader = new StreamReader(INPUT))
            {
                string line = reader.ReadLine();
                string[] whd = line.Split(' ');
                W = int.Parse(whd[0]);
                H = int.Parse(whd[1]);
                D = int.Parse(whd[2]);

                cuboid = new char[W, H, D];

                for (int y = 0; y < H; y++)
                {
                    line = reader.ReadLine();
                    string[] sequences = line.Split(' ');
                    for (int z = 0; z < D; z++)
                    {
                        string sequence = sequences[z];
                        for (int x = 0; x < W; x++)
                        {
                            cuboid[x, y, z] = sequence[x];
                        }
                    }
                }
            }
        }

        private static void Input()
        {
            string line = Console.ReadLine();
            string[] whd = line.Split(' ');
            W = int.Parse(whd[0]);
            H = int.Parse(whd[1]);
            D = int.Parse(whd[2]);

            cuboid = new char[W, H, D];

            for (int y = 0; y < H; y++)
            {
                line = Console.ReadLine();
                string[] sequences = line.Split(' ');
                for (int z = 0; z < D; z++)
                {
                    string sequence = sequences[z];
                    for (int x = 0; x < W; x++)
                    {
                        cuboid[x, y, z] = sequence[x];
                    }
                }
            }
        }

        private static void FindStars()
        {
            for (int x = 1; x < W - 1; x++)
            {
                for (int y = 1; y < H - 1; y++)
                {
                    for (int z = 1; z < D - 1; z++)
                    {
                        char centerCube = cuboid[x, y, z];
                        bool sameColorNeighbours = CheckNeighbours(cuboid[x, y, z], x, y, z);
                        if (sameColorNeighbours)
                        {
                            if (stars.ContainsKey(centerCube))
                            {
                                stars[centerCube]++;
                            }
                            else
                            {
                                stars.Add(centerCube, 1);
                            }
                        }
                    }
                }
            }
        }

        private static bool CheckNeighbours(char center, int x, int y, int z)
        {
            // check 6 neighbouring cells
            char up = cuboid[x, y - 1, z];
            char down = cuboid[x, y + 1, z];
            char left = cuboid[x - 1, y, z];
            char right = cuboid[x + 1, y, z];
            char front = cuboid[x, y, z - 1];
            char behind = cuboid[x, y, z + 1];

            if (center == up && center == down && center == left && center == right && center == front && center == behind)
            {
                return true;
            }

            return false;
        }

        static void PrintResult()
        {
            int count = 0;
            foreach (KeyValuePair<char, int> star in stars)
            {
                count += star.Value;
            }
            Console.WriteLine(count);
            foreach (KeyValuePair<char, int> star in stars)
            {
                Console.WriteLine(star.Key + " " + star.Value);
            }
        }
    }
}
