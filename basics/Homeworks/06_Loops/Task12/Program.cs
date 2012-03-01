using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task12
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that reads from the console a 
            //positive integer number N (N < 20) and outputs a matrix like the following:
	        //N = 3			N = 4

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
            int counter = 1;

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    matrix[i, j] = counter;
                    counter++;
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
