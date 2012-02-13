using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace P4._3DStars
{
    class Program
    {
        private static char[,,] theCubeofInsanity;
        private static int width;
        private static int height;
        private static int depth;

        static void Main(string[] args)
        {
            InitCube();           
            Dictionary<char, int> stars = new Dictionary<char, int>();
            int starsCount = 0;
            for (int w = 1; w < width -1; w++)
            {
                for (int h = 1; h < height -1; h++)
                {
                    for (int d = 1; d < depth - 1; d++)
                    {
                        char color = theCubeofInsanity[w, h, d];
                        if (Find3DStar(w, h, d, color))
                        {
                            starsCount++;
                            if (stars.ContainsKey(color) == false)
                            {
                                stars.Add(color, 1);
                            }
                            else
                            {
                                stars[color]++;
                            }
                        }
                    }
                }
            }
            List<Tuple<char, int>> sorted = new List<Tuple<char, int>>();
            foreach (var star in stars)
            {
                sorted.Add(new Tuple<char,int>(star.Key, star.Value));
            }
            sorted = sorted.OrderBy(x => x.Item1).ToList(); //(x => x.Item1).ToList();
            Console.WriteLine(starsCount);
            foreach (var star in sorted)
            {
                Console.WriteLine(star.Item1 + " " + star.Item2);
            }
        }

        private static bool Find3DStar(int W,int H,int D,char color)      
        {           
            if (!(IsInsideTheCuboid(W + 1, H, D) && theCubeofInsanity[W + 1, H, D] == color))
            {
                return false;
            }
            
            if (!(IsInsideTheCuboid(W - 1, H, D) && theCubeofInsanity[W - 1, H, D] == color))
            {
                return false;
            }
            if (!(IsInsideTheCuboid(W , H + 1, D) && theCubeofInsanity[W , H + 1, D] == color))
            {
                return false;
            }
            if (!(IsInsideTheCuboid(W , H - 1, D) && theCubeofInsanity[W, H -1 , D] == color))
            {
                return false;
            }
            if (!(IsInsideTheCuboid(W, H , D + 1) && theCubeofInsanity[W, H , D + 1] == color))
            {
                return false;
            }
            if (!(IsInsideTheCuboid(W, H, D - 1) && theCubeofInsanity[W, H, D - 1] == color))
            {
                return false;
            }
            return true;
        }

        private static void InitCube()
        {
            //using (StreamReader reader = new StreamReader("..\\..\\Input2.txt"))
           // {
                string[] sizes = Console.ReadLine().Split(' ');
                width = int.Parse(sizes[0]);
                height = int.Parse(sizes[1]);
                depth = int.Parse(sizes[2]);
                theCubeofInsanity = new char[width, height, depth];
                
                // Read the cuboid data
                for (int h = 0; h < height; h++)
                {
                    string line = Console.ReadLine();
                    string[] letters = line.Split();
                    for (int d = 0; d < depth; d++)
                    {
                        for (int w = 0; w < width; w++)
                        {
                            theCubeofInsanity[w, h, d] = letters[d][w];
                        }
                    }
                }
            //}
        }

        private static bool IsInsideTheCuboid(int w, int h, int d)
        {
            bool inside =
                w >= 0 && w < width &&
                h >= 0 && h < height &&
                d >= 0 && d < depth;
            return inside;
        }
    }
}
