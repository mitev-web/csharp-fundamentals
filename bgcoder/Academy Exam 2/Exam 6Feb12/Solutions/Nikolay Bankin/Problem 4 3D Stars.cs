using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3DStar
{
    class Program
    {
        private const int MAX_WIDTH_INDEX = 150;
        private const int MAX_HEIGHT_INDEX = 150;
        private const int MAX_DEPTH_INDEX = 150;
        //private const int MAX_STAR_NUMBER = (MAX_DEPTH-2)*(MAX_HEIGHT-2)*(MAX_WIDTH-2);
        private static int width;
        private static int height;
        private static int depth;
        private static char[, , ,] cuboid;
        private static int [] foundStars = new int[26];
        private static int starsNumber=0;


        static void Main(string[] args)
        {            
            for (int i = 0; i < foundStars.Length; i++)
            {
                foundStars[i] = 0;
            }
            readInputCuboid();
            if ((width < 3) || (height < 3) || (depth < 3))
            {
                Console.WriteLine(0);
                return;
            }
            searchStars(1,1,1);

            Console.WriteLine(starsNumber);
            for (int i = 0; i < foundStars.Length; i++)
            {
                if (foundStars[i] != 0)
                {
                    Console.WriteLine("{0} {1}",(char)(i+65),foundStars[i]);
                }
            }
        }

        private static void searchStars(int currentWidth,int currentHeight, int currentDepth)
        {
            if (cuboid[currentWidth, currentHeight, currentDepth, 1] == '0')
            {
                return;
            }
            else if (((currentWidth - 1) < 0))
            {
                //Console.WriteLine("1");
                return;
            }
            else if((currentWidth + 1) >= width)
            {
                return;
            }
            else if(((currentHeight-1) < 0))
            {
                //Console.WriteLine("2");
                return;
            }
            else if ((currentHeight+1) >= height)
            {
                return;
            }
            else if (((currentDepth - 1) < 0))
            {
                //Console.WriteLine("3");
                return;
            }
            else if ((currentDepth + 1) >= depth)
            {
                return;
            }
            else
            {
                char currentColor = cuboid[currentWidth, currentHeight, currentDepth, 0];
                cuboid[currentWidth, currentHeight, currentDepth, 1] = '0';
                if (starConditions(currentWidth, currentHeight, currentDepth, currentColor))
                {
                    foundStars[(int)currentColor - 'A']++;
                    starsNumber++;
                }

                searchStars(currentWidth + 1, currentHeight, currentDepth);
                searchStars(currentWidth - 1, currentHeight, currentDepth);
                searchStars(currentWidth, currentHeight + 1, currentDepth);
                searchStars(currentWidth, currentHeight - 1, currentDepth);
                searchStars(currentWidth, currentHeight, currentDepth + 1);
                searchStars(currentWidth, currentHeight, currentDepth - 1);
            }
        }

        private static bool starConditions(int currentWidth, int currentHeight, int currentDepth, char currentColor)
        {
            if(currentColor == cuboid[currentWidth+1,currentHeight,currentDepth,0])
            {
                //Console.WriteLine("FUUU !! 1");
                if (currentColor == cuboid[currentWidth - 1, currentHeight, currentDepth,0])
                {
                    //Console.WriteLine("FUUU !! 2");
                    if (currentColor == cuboid[currentWidth, currentHeight+1, currentDepth,0])
                    {
                        //Console.WriteLine("FUUU  3 !!");
                        if (currentColor == cuboid[currentWidth, currentHeight - 1, currentDepth,0])
                        {
                            //Console.WriteLine("FUUU 4 !!");
                            if (currentColor == cuboid[currentWidth, currentHeight, currentDepth+1,0])
                            {
                                //Console.WriteLine("FU 5 SUU !!");
                                if (currentColor == cuboid[currentWidth, currentHeight, currentDepth - 1,0])
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private static void readInputCuboid()
        {
            string lineReader;
            lineReader = Console.ReadLine();
            string[] dimentions = lineReader.Split(' ');
            width = int.Parse(dimentions[0]);
            height = int.Parse(dimentions[1]);
            depth = int.Parse(dimentions[2]);       
            cuboid = new char[width,height,depth,2];
            
            for (int h = 0; h < height; h++)
            {
                lineReader = Console.ReadLine();
                string[] widthColors = lineReader.Split(' ');
                for (int d = 0; d < depth; d++)
                {
                    char[] inputData = widthColors[d].ToCharArray();
                    for (int w = 0; w < width; w++)
                    {
                        //Console.WriteLine("D == {0}, W == {1}",d,w);
                        cuboid[w,h,d,0] = inputData[w];
                    }
                }
            }
        }
    }
}
