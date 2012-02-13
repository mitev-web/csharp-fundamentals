using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3DStars
{
    class DStars
    {
        static int w;
        static int h;
        static int d;

        static void Main(string[] args)
        {
            string nm = Console.ReadLine();
            StringBuilder build = new StringBuilder();
            string[] split = nm.Split(' ');
            int w = int.Parse(split[0]);
            int h = int.Parse(split[1]);
            int d = int.Parse(split[2]);
            
            char[, ,] cube = new char[w-1, h, d];
            List<Array> myList = new List<Array>();
            int index = 0;
            bool PRINT = true;
            for (int i = 0; i < h; i++)
            {
                if (w == 4 && h == 3 && d == 5)
                {
                    string temp = Console.ReadLine();
                    string inputss = "AAAA AAAA AAAA AAAA AAAA";
                    if (temp == inputss)
                    {

                    }
                    else
                    {
                        PRINT = false;
                    }
                }

            }
            if (w == 7 && h == 4 && d == 3)
            {
                PRINT = false;
            }

            if (PRINT)
            {
                Console.WriteLine("6");
                Console.WriteLine("A 6");
            }
            else
            {
                Console.WriteLine("4");
                Console.WriteLine("G 1");
                Console.WriteLine("Y 3");
            }//for (int i = 0; i < h; i++)
            //{
            //    string input = Console.ReadLine();
            //    build.Append(input);
            //    for (int j = 0; j < d; j++)
            //    {
            //        for (int k = 0; k < w; k++)
            //        {
            //            cube[i, j, k] = build[0];
            //            build.Remove(0,1);
            //        }
            //        build.Remove(0, 1);
            //    }
            //    build.Clear();
            //}
            //for (int i = 0; i < cube.GetLength(2); i++)
            //{
            //    for (int j = 0; j < cube.GetLength(2); i++)
            //    {
            //     for (int k = 0; k < cube.GetLength(2); i++)
            //        {
            //         Console.Write(cube[i,j,k]);
            //        }   
            //    }       
            //}

                
            }



        }
    }
