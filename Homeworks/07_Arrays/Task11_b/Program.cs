using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task11_b
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that fills and prints a matrix of size (n, n) as shown below: (examples for n = 4)
            int N = int.Parse(Console.ReadLine());

            int direction = 0;
            int[,] arr = new int[N, N];


            int positionX = 0;
            int positionY = 0;

            for (int i = 1; i < N * N+1; i++)
            {
                arr[positionY, positionX] = i;

                if (i % N == 0)
                    direction++;

                switch (direction % 4)
                {
                    case 0://down
                        positionY++;
                        break;
                    case 1://right
                        positionX++;
                        direction++;
                        break;
                    case 2://up
                        positionY--;
                        break;
                    case 3://right
                        positionX++;
                        direction++;
                        break;
                }
            }

            PrintMatrix(arr);
        }

        private static void PrintMatrix(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("{0,3}", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
