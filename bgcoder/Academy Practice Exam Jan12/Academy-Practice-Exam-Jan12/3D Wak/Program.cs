using System;
using System.Linq;

namespace _3D_Wak
{
    class Program
    {
        static short[,,] cuboid = null;
       
        static int width;
        static int height;
        static int depth;
        static void Main(string[] args)
        {
            cuboid = new short[width, height, depth];

            FillCuboid();
            PrintCuboid();
     
        }

        static void StartWalking(int w, int h, int d)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        static void FillCuboid()
        {
            string sizes = Console.ReadLine();
            string[] dimentions = sizes.Split();
            width = int.Parse(dimentions[0]);
            height = int.Parse(dimentions[1]);
            depth = int.Parse(dimentions[2]);
            cuboid = new short[width, height, depth];


            for (int h = 0; h < height; h++)
            {
                string line = Console.ReadLine();
                string[] sequences = line.Split('|');
                for (int d = 0; d < depth; d++)
                {
                    string[] numbers = sequences[d].Split(
                        new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int w = 0; w < width; w++)
                    {
                        short cubeValue = short.Parse(numbers[w]);
                        cuboid[w, h, d] = cubeValue;
                    }
                }
            }
             
          
        }

        static void PrintCuboid()
        {
            for (int h = 0; h < height; h++)
            {
                for (int d = 0; d < depth; d++)
                {
                    for (int w = 0; w < width; w++)
                    {
                        Console.Write(cuboid[w, h, d]);
                    }
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}