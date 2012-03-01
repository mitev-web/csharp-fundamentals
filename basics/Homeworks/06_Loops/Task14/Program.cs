using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task14
{
    class Program
    {
        static void Main(string[] args)
        {
            //* Write a program that reads a positive integer number N (N < 20) 
            //from console and outputs in the console the numbers 1 ... N numbers arranged as a spiral.
		    //Example for N = 4

            int N = new int();
            Console.WriteLine("Enter Matrix size (N) - between 1 and 20");
            if (!int.TryParse(Console.ReadLine(), out N) && N < 20)
            {
                Console.WriteLine("Invalid Input");
            }

            int[,] matrix = new int[N, N];

            PopulateMatrix(matrix);
            PrintMatrix(matrix);
        }

        private static void PopulateMatrix(int[,] matrix)
        {
            int N = matrix.GetLength(0);
            int positionX = -1;
            int positionY = 0;
            int direction = 0;
            int currentPosition = 0;
            int changeDirection = N - 1;

            for (int j = 1; j <= N; j++)
            {
                positionX++;
                matrix[positionY, positionX] = j;
            }

            for (int i = N + 1; i <= N * N; i++)
            {
                currentPosition++;
                switch (direction % 4)
                {
                    //down
                    case 0:
                        positionY++;
                        break;
                    case 1:
                        //left
                        positionX--;
                        break;
                    //up
                    case 2:
                        positionY--;
                        break;
                    //right
                    case 3:
                        positionX++;
                        break;
                }

                matrix[positionY, positionX] = i;

                if (currentPosition == changeDirection)
                {
                    currentPosition = 0;
                    direction++;
                    if (direction % 2 == 0)
                        changeDirection--;
                }
            }

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
