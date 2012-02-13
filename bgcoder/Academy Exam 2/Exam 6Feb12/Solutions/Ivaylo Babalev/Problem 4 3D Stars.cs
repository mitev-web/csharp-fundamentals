using System;
using System.Linq;

namespace _04._3D_Stars
{
    class Program
    {
        static int width, height, depth;
        static int starsCount;
        static char[] alphabet;
        static char[, ,] cuboid;
        static int[] alphabetCounter;
        
        static void Main(string[] args)
        {
            alphabet = new char[26];
            alphabetCounter = new int[26];
            for (int i = 0; i < alphabet.Length; i++)
            {
                alphabet[i] = (char)(65+i);
                alphabetCounter[i] = 0;
            }

            ReadCuboid();

            FindStar(cuboid);

            Console.WriteLine(starsCount);
            for (int i = 0; i < alphabetCounter.Length; i++)
            {
                if (alphabetCounter[i]!=0)
                {
                    Console.WriteLine("{0} {1}",alphabet[i],alphabetCounter[i]);
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

        private static void FindStar(char[,,] cuboid)
        {

            for (int startW = 1; startW < width-1; startW++)
            {
                for (int startH = 1; startH < height-1; startH++)
                {
                    for (int startD = 1; startD < depth-1; startD++)
                    {
                        IsItAStar(startW, startH, startD);
                    }
                }
            }
        }

        private static void IsItAStar(int startW, int startH, int startD)
        {
            bool inWidth = false;
            bool inDepth = false;
            bool inHeight = false;
            if ((cuboid[startW,startH,startD]==cuboid[(startW-1),startH,startD]) && (cuboid[startW,startH,startD]==cuboid[(startW+1),startH,startD]))
            {
                inWidth = true;
            }
            if (cuboid[startW, startH, startD] == cuboid[startW, startH-1, startD] && cuboid[startW, startH, startD] == cuboid[startW, startH+1, startD])
            {
                inHeight = true;
            }
            if (cuboid[startW, startH, startD] == cuboid[startW, startH, startD-1] && cuboid[startW, startH, startD] == cuboid[startW, startH, startD+1])
            {
                inDepth = true;
            }

            if (inDepth)
            {
                if (inHeight)
                {
                    if (inWidth)
                    {
                        starsCount++;
                        for (int i = 0; i < alphabet.Length; i++)
                        {
                            if (cuboid[startW, startH, startD]==alphabet[i])
                            {
                                alphabetCounter[i]++;
                            }
                        }
                    }
                }
            }
        }
    }
}
