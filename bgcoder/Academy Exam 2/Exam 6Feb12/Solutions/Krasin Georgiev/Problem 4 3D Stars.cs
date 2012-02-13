using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Stars3D
{
    static int width;
    static int height;
    static int depth;
    static char[, ,] cuboid;    

    static void Main()
    {
        ReadCuboid();
        string stars = CountStars();
        Console.WriteLine(stars.Length);
        PrintStars(stars);
    }

    private static void PrintStars(string text)
    {
        char[] indexArray = new char[65536];
        for (int i = 0; i < text.Length; i++)
        {
            indexArray[(short)text[i]]++;
        }
        for (int i = (int)'A'; i <= (int)'Z'; i++)
        {
            if (indexArray[i]!=0)
            {
                Console.WriteLine("{0} {1}", (char)i, (int)indexArray[i]);
            }            
        }  
    }

    private static string CountStars()
    {
        StringBuilder starInventory = new StringBuilder();
        char currentColor;
        bool isStar = false;
        for (int w = 1; w < width-1; w++)
        {
            for (int h = 1; h < height-1; h++)
            {
                for (int d = 1; d < depth-1; d++)
                {
                    currentColor = cuboid[w, h, d];
                    isStar = currentColor == cuboid[w + 1, h, d] &&
                        currentColor == cuboid[w - 1, h, d] &&
                        currentColor == cuboid[w, h + 1, d] &&
                        currentColor == cuboid[w, h - 1, d] &&
                        currentColor == cuboid[w, h, d + 1] &&
                        currentColor == cuboid[w, h, d - 1];
                    if (isStar)
                    {
                        starInventory.Append(currentColor);
                    }
                }
            }
        }
        return starInventory.ToString();
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
                    char color = sequences[d][w];
                    cuboid[w, h, d] = color;
                }
            }
        }
    }
}
