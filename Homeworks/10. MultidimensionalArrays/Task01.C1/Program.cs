using System;
using System.Linq;

namespace Task01.C1
{
    class Program
    {
        static int[,] matrix = null;

        //Write a program that fills and prints a matrix of size (n, n) as shown below:
        //(examples for n = 4)

        //7 11  14 16
        //4  8  12 15
        //2  5  9  13
        //1  3  6  10
        static void Main(string[] args)
        {
            int N = 4;
            matrix = new int[N, N];
            int value = 1;
            int diagonalColumns = 0;
            for (int i = N - 1; i >= -N; i--, diagonalColumns++)
            {
                for (int j = 0; j <= diagonalColumns; j++)
                {
                    if (IsOutsideOfArray(i + j, j))
                    {
                        continue;
                    }
                    else
                    { 
                        matrix[i + j, j] = value;
                        value++;
                    }
                }
            }
        PrintMatrix(matrix);

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


        static bool IsOutsideOfArray(int y, int x)
        {
            if (y < 0 || y >= matrix.GetLength(0) || x < 0 || x >= matrix.GetLength(1))
                return true;
            else
                return false;
        }
    }
}

