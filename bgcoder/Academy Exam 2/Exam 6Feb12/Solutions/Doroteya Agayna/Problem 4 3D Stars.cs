using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3DStars
{
    class Program
    {
        static void CreateCuboid(char[, ,] cube)
        {
            string[] tokens;
            for (int i = 0; i < cube.GetLength(1); i++)
            {
                tokens = Console.ReadLine().Split(' ');
                for (int j = 0; j < cube.GetLength(2); j++)
                {
                    for (int k = 0; k < cube.GetLength(0); k++)
                    {
                        cube[k, i, j] = tokens[j][k];
                        if (!dictionary.ContainsKey(tokens[j][k]))
                        {
                            dictionary.Add(tokens[j][k], 0);
                        }
                    }
                }
            }
        }

        static int counter = 0;
        static SortedDictionary<char, int> dictionary = new SortedDictionary<char, int>();
        
        static int LookForTheStars(char[,,] cube, char center, int w, int h, int d)
        {
            int isMatch = 0;
            if (w < 0 || w >= cube.GetLength(0))
            {
                return 0;
            }
            if (h < 0 || h >= cube.GetLength(1))
            {
                return 0;
            }
            if (d < 0 || d >= cube.GetLength(2))
            {
                return 0;
            }
            if (center == cube[w, h, d])
            {
                isMatch = 1;
            }
            return isMatch;
        }

        static void TraverseCuboid(char[, ,] cube)
        {
            int isMatch = 0;
            for (int i = 0; i < cube.GetLength(0); i++)
            {
                for (int j = 0; j < cube.GetLength(1); j++)
                {
                    for (int k = 0; k < cube.GetLength(2); k++)
                    {
                        isMatch = 0;
                        isMatch += LookForTheStars(cube, cube[i, j, k], i + 1, j, k);
                        isMatch += LookForTheStars(cube, cube[i, j, k], i - 1, j, k);
                        isMatch += LookForTheStars(cube, cube[i, j, k], i, j + 1, k);
                        isMatch += LookForTheStars(cube, cube[i, j, k], i, j - 1, k);
                        isMatch += LookForTheStars(cube, cube[i, j, k], i, j, k + 1);
                        isMatch += LookForTheStars(cube, cube[i, j, k], i, j, k - 1);
                        if (isMatch == 6)
                        {
                            counter++;
                            dictionary[cube[i, j, k]]++;
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split(' ');
            char[,,] cuboid = new char[int.Parse(tokens[0]), int.Parse(tokens[1]), int.Parse(tokens[2])];

            CreateCuboid(cuboid);
            TraverseCuboid(cuboid);
            Console.WriteLine(counter);
            foreach (var dict in dictionary)
            {
                if (dict.Value != 0)
                {
                    Console.WriteLine(dict.Key + " " + dict.Value);
                }
            }
        }
    }
}
