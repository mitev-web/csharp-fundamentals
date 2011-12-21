using System;
using System.Linq;

namespace Task_11d
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that fills and prints a matrix of size (n, n) as shown below:
            //(examples for n = 4)

            //1  12  11 10
            //2  13  16  9
            //3  14  15  8
            //4   5   6  7


            int N = int.Parse(Console.ReadLine());
            
            int direction = 0;
            int[,] arr = new int[N, N];


            for (int i = 1; i < N; i++)
            {
                
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
