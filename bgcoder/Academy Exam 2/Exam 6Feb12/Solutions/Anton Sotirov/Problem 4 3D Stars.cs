using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace problem4
{
    class Program
    {
        static int w, h, d;
        static int[, ,] cube;
        static bool checkStar(int x, int y, int z)
        {
            int color = cube[x, y, z];
            int[,] near={{1,0,0},{0,1,0},{0,0,1},{-1,0,0},{0,-1,0},{0,0,-1}};
                if (color ==( cube[x+near[0,0], y + near[0, 1], z + near[0, 2]]) && 
                    color ==( cube[x+near[1,0], y + near[1, 1], z + near[1, 2]]) && 
                    color == (cube[x+near[2,0], y + near[2, 1], z + near[2, 2]])&& 
                    color == (cube[x+near[3,0], y + near[3, 1], z + near[3, 2]])&& 
                    color ==( cube[x+near[4,0], y + near[4, 1], z + near[4, 2]])&& 
                    color == (cube[x+near[5,0], y + near[5, 1], z + near[5, 2]]))
                return true;   
            else
                {                   
                    return false;
                }
        }
        static int[] stars = new int[28];
        static void Main(string[] args)
        {
            int total = 0;
            string[] ints = Console.ReadLine().Split();
            w = int.Parse(ints[0]);//4
            h = int.Parse(ints[1]);//3
           
            d = int.Parse(ints[2]); //5

            cube = new int[w, h, d];
            for (int i = 0; i < h; i++)
            {
                string line = Console.ReadLine();
                int index = 0;
                for(int j=0;j<d;j++)
                {
                    for(int k=0;k<w;k++)
                    {
                        
                        char c=line[index++];
                        
                        cube[k, i , j] =  c;
                    }
                    index++;
                }
            }
            for(int i=1;i<w-1;i++)
                for(int j=1;j<h-1;j++)
                    for (int k = 1; k < d - 1; k++)
                    {
                        if (checkStar(i, j, k))
                        {
                            stars[cube[i, j, k]-65]++;
                            total++;
                        }
                    }
            Console.WriteLine(total);
            for (int i = 0; i < stars.Length; i++)
            {
                if (stars[i] > 0)
                {
                    Console.WriteLine((char)(i+65)+" "+stars[i]);
                }
            }
        }
    }
}
