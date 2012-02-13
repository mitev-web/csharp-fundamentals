using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
namespace Problem_4_3D_Stars
{
    class Stars3D
    {
        static int width, height, depth;
        static char[, ,] cuboid;
        static List<char> stars = new List<char>();
        
        static void Main()
        {
            // Read the cuboid
            ReadCuboid();
                                 
            // Find the stars in the cuboid
            FindStar();
 
            // Print the result
            if (stars != null)
            {
                Console.WriteLine(stars.Count);
                stars.Sort();
                int count = 1;
                for (int i = 0; i < stars.Count - 1; i++)
                {
                    if (stars[i] == stars[i + 1])
                        {
                            count++;
                            if (i == stars.Count - 2)
                            {
                                Console.WriteLine("{0} {1}", stars[i], count);
                            }
                            else {continue;}
                        }
                    else if (i == stars.Count - 2)
                    {
                        Console.WriteLine("{0} {1}", stars[i], count); count = 1;
                        Console.WriteLine("{0} {1}", stars[i + 1], count);
                    }
                    else {Console.WriteLine("{0} {1}", stars[i], count); count = 1; }
                }         
            }
            else
            {
                Console.WriteLine(-1);
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
            for (int startW = 1; startW < width - 1; startW++)
            {
                for (int startH = 1; startH < height - 1; startH++)
                {
                    for (int startD = 1; startD < depth - 1; startD++)
                    {
 
                        CheckIfStar(startW, startH, startD);
                    }
                }
            }
        }
 
        private static void CheckIfStar(int w, int h, int d)
        {
            char color = cuboid[w, h, d];
 
            // Find the star
 
            if (cuboid[w + 1, h, d] == color && cuboid[w - 1, h, d] == color && cuboid[w, h + 1, d] == color && cuboid[w, h - 1, d] == color && cuboid[w, h, d - 1] == color && cuboid[w, h, d + 1] == color)
            {
                stars.Add(color);
            }
 
             
        }
 
    }
}