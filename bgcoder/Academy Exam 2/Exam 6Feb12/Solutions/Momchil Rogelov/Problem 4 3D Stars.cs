using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3Dstars
{
    class Program
    {
        static void Main(string[] args)
        {
            string size = Console.ReadLine();
            string[] sizes = size.Split(' ');
            int[] sizesN = new int[sizes.Length];
            for (int i = 0; i < sizes.Length; i++)
            {
                sizesN[i] = int.Parse(sizes[i]);
            }
            byte width = (byte)sizesN[0];
            byte height = (byte)sizesN[1];
            byte depth = (byte)sizesN[2];
            //paring the space
            char[, ,] space = new char[width, height, depth];

            for (int h = 0; h < height; h++)
            {
                string line = Console.ReadLine();
                string[] depthlaters = line.Split(' ');
                for (int d = 0; d < depth; d++)
                {
                    string todostring = depthlaters[d];
                    for (int w = 0; w < width; w++)
                    {
                        space[w, h, d] = todostring[w];
                    }
                }
            }
            int stars=0;
            int?[] rep = new int?[128];

            //now find stars
            for (int w = 1; w < width-1; w++)
            {
                for (int h = 1; h < height-1; h++)
                {
                    for (int d = 1; d < depth-1; d++)
                    {
                        char color = space[w, h, d];
                        if(
                           (color==space[w+1,h,d]&&color==space[w-1,h,d])
                            &&
                           (color==space[w,h+1,d]&&color==space[w,h-1,d])
                            &&
                           (color==space[w,h,d+1]&&color==space[w,h,d-1])
                          )
                        {
                            stars++;
                            if (rep[(int)color] == null)
                            {
                                rep[(int)color] = 1;
                            }
                            else
                            {
                                rep[(int)color] += 1;
                            }
                        }
                    }
                }
            }

            Console.WriteLine(stars);
            for (int i = 0; i < rep.Length; i++)
            {
                if (rep[i] != null) 
                {
                    Console.Write((char)i+" ");
                    Console.WriteLine(rep[i]);
                }
            }
        }
    }
}
