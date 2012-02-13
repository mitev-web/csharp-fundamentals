using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3D_Stars
{
    class Program
    {
        static readonly int[,] directions =
        {
            {1, 0, 0},
            {-1, 0, 0},
            {0, 1, 0},
            {0, -1, 0},
            {0, 0, 1},
            {0, 0, -1}
        };

        static char[, ,] cuboid;
        static int[] starsCounter = new int[26];
        static int counter = 0;

        static void Main(string[] args)
        {
            GetDimensions();
            GetColors();
            FindAllStars();
            Console.WriteLine(counter);
            StringBuilder result = new StringBuilder(26 * 4);
            for (int i = 0; i < starsCounter.Length; i++)
            {
                if (starsCounter[i] > 0)
                {
                    result.AppendLine(string.Format("{0} {1}", (char)(i + 65), starsCounter[i]));
                }
            }
            Console.WriteLine(result);
        }

        static void GetDimensions()
        {
            string[] input = Console.ReadLine().Split();
            int col = int.Parse(input[0]);
            int row = int.Parse(input[1]);
            int depth = int.Parse(input[2]);
            cuboid = new char[row, col, depth];
        }

        static void GetColors()
        {
            for (int row = 0; row < cuboid.GetLength(0); row++)
            {
                string[] lines = Console.ReadLine().Split();
                for (int depth = 0; depth < cuboid.GetLength(2); depth++)
                {
                    for (int col = 0; col < cuboid.GetLength(1); col++)
                    {
                        cuboid[row, col, depth] = lines[depth][col];
                    }
                }
            }
        }

        static void FindAllStars()
        {
            for (int row = 1; row < cuboid.GetLength(0) - 1; row++)
            {
                for (int col = 1; col < cuboid.GetLength(1) - 1; col++)
                {
                    for (int depth = 1; depth < cuboid.GetLength(2) - 1; depth++)
                    {
                        if (IsStar(row, col, depth))
                        {
                            char color = cuboid[row, col, depth];
                            starsCounter[color - 65]++;
                            counter++;
                        }
                    }
                }
            }
        }
  
        private static bool IsStar(int row, int col, int depth)
        {
            char color = cuboid[row, col, depth];
            for (int i = 0; i < directions.GetLength(0); i++)
            {
                int nextRow = row + directions[i, 0];
                int nextCol = col + directions[i, 1];
                int nextDepth = depth + directions[i, 2];
                if (cuboid[nextRow, nextCol, nextDepth] != color)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
