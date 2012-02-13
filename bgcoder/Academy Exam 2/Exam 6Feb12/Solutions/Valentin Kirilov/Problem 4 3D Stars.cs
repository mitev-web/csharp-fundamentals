using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stars
{
    class Stars
    {

        static int width;
        static int height;
        static int depth;
        static char[, ,] cuboid;
        static Dictionary<char, int> foundStars;
        static int foundStarsNumber;

        static void Main(string[] args)
        {
            ReadCuboid();
            //PrintCuboid();

            //UnitTests();
            foundStars = new Dictionary<char, int>();
            foundStarsNumber = 0;

            // Find Solution
            for (int h = 1; h < cuboid.GetLength(1)-1; h++)
            {
                for (int d = 1; d < cuboid.GetLength(2)-1; d++)
                {
                    for (int w = 0; w < cuboid.GetLength(0); w++)
                    {
                        CheckStar(w, h, d);
                    }
                }
            }

            PrintResult();
        }

        private static void PrintResult()
        {
            // Write result
            Console.WriteLine(foundStarsNumber);

            var sortedResult = foundStars.Keys.ToList();
            sortedResult.Sort();
            foreach (var key in sortedResult)
            {
                Console.WriteLine("{0} {1}", key, foundStars[key]);
            }
        }

        private static void UnitTests()
        {
            // JUnit tests :D :: Check Valid Cube
            //Console.WriteLine(CheckValidCube(0, 0, 0, 'A'));
            //Console.WriteLine(CheckValidCube(0, 0, 0, 'B'));
            //Console.WriteLine(CheckValidCube(-1, 0, 0, 'A'));
            //Console.WriteLine(CheckValidCube(0, -1, 0, 'A'));
            //Console.WriteLine(CheckValidCube(0, 0, -1, 'A'));
            //Console.WriteLine(CheckValidCube(3, 0, 0, 'A'));
            //Console.WriteLine(CheckValidCube(0, 3, 0, 'A'));
            //Console.WriteLine(CheckValidCube(0, 0, 3, 'A'));
            //Console.WriteLine(CheckValidCube(4, 0, 0, 'A'));
            //Console.WriteLine(CheckValidCube(0, 4, 0, 'A'));
            //Console.WriteLine(CheckValidCube(0, 0, 4, 'A'));

            // Check valid star
            //Console.WriteLine(CheckStar(0, 0, 0));
            //Console.WriteLine(CheckStar(1, 1, 1));
            //Console.WriteLine(CheckStar(1, 2, 1));
            //Console.WriteLine(CheckStar(2, 2, 2));
            //Console.WriteLine(CheckStar(4, 4, 4));
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
                        cuboid[w, h, d] = sequences[d][w];
                    }
                }
            }
        }

        private static void PrintCuboid()
        {
            for (int h = 0; h < cuboid.GetLength(1); h++)
            {
                for (int d = 0; d < cuboid.GetLength(2); d++)
                {
                    for (int w = 0; w < cuboid.GetLength(0); w++)
                    {
                        Console.Write(cuboid[w, h, d]);
                    }
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        private static bool CheckStar(int wIndex, int hIndex, int dIndex)
        {
            // Check is inside the cuboid
            if (wIndex < 0 || wIndex >= cuboid.GetLength(0))
                return false;
            if (hIndex < 0 || hIndex >= cuboid.GetLength(1))
                return false;
            if (dIndex < 0 || dIndex >= cuboid.GetLength(2))
                return false;            

            //Console.WriteLine(CheckValidCube(wIndex+1, hIndex, dIndex, cuboid[wIndex, hIndex, dIndex]));
            //Console.WriteLine(CheckValidCube(wIndex-1, hIndex, dIndex, cuboid[wIndex, hIndex, dIndex]));
            //Console.WriteLine(CheckValidCube(wIndex, hIndex+1, dIndex, cuboid[wIndex, hIndex, dIndex]));
            //Console.WriteLine(CheckValidCube(wIndex, hIndex-1, dIndex, cuboid[wIndex, hIndex, dIndex]));
            //Console.WriteLine(CheckValidCube(wIndex, hIndex, dIndex+1, cuboid[wIndex, hIndex, dIndex]));
            //Console.WriteLine(CheckValidCube(wIndex, hIndex, dIndex-1, cuboid[wIndex, hIndex, dIndex]));

            bool checkValidStar = (CheckValidCube(wIndex+1, hIndex, dIndex, cuboid[wIndex, hIndex, dIndex])
                & CheckValidCube(wIndex-1, hIndex, dIndex, cuboid[wIndex, hIndex, dIndex])
                & CheckValidCube(wIndex, hIndex+1, dIndex, cuboid[wIndex, hIndex, dIndex])
                & CheckValidCube(wIndex, hIndex-1, dIndex, cuboid[wIndex, hIndex, dIndex])
                & CheckValidCube(wIndex, hIndex, dIndex+1, cuboid[wIndex, hIndex, dIndex])
                & CheckValidCube(wIndex, hIndex, dIndex-1, cuboid[wIndex, hIndex, dIndex]));

            if (checkValidStar == true) 
            {
                if (foundStars.ContainsKey(cuboid[wIndex, hIndex, dIndex]) == true)
                {
                    int currentStarsOfThisColor = foundStars[cuboid[wIndex, hIndex, dIndex]];
                    foundStars.Remove(cuboid[wIndex, hIndex, dIndex]);
                    foundStars.Add(cuboid[wIndex, hIndex, dIndex], currentStarsOfThisColor + 1);
                    foundStarsNumber++;
                }
                else
                {
                    foundStars.Add(cuboid[wIndex, hIndex, dIndex], 1);
                    foundStarsNumber++;
                }
                return true;
            }
            else
                return false;
        }

        private static bool CheckValidCube(int wIndex, int hIndex, int dIndex, char color)
        {
            // Check is inside the cuboid
            if (wIndex < 0 || wIndex >= cuboid.GetLength(0))
                return false;
            if (hIndex < 0 || hIndex >= cuboid.GetLength(1))
                return false;
            if (dIndex < 0 || dIndex >= cuboid.GetLength(2))
                return false;

            // Check color
            if (cuboid[wIndex, hIndex, dIndex] != color)
                return false;

            return true;
        }
    }
}
