using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task02
{
    class Program
    {
        public static int[,] matrix =
            {
                { 1, 3, 2, 2, 2, 4 },
                { 3, 3, 3, 2, 9, 4 },
                { 4, 7, 1, 2, 12, 9 },
                { 4, 3, 1, 4, 1, 31 },
                { 4, 3, 3, 1, 4, 22 },
            };
        static void Main(string[] args)
        {
            //Write a program that reads a rectangular matrix of
            //    size N x M and finds in it the square 3 x 3 
            //that has maximal sum of its elements.
            long maxSum = int.MinValue;
            long tempSum = 0;
            int row = 0;
            int col = 0;
      

            for (int i = 0; i < matrix.GetLength(0)-2; i++)
            {
                for (int j = 0; j <  matrix.GetLength(1)-2; j++)
                {
                    tempSum = matrix[i, j] + matrix[i + 1, j] + matrix[i + 2, j] + matrix[i, j + 1] + matrix[i, j + 2]
                           + matrix[i + 1, j + 1] + matrix[i + 1, j + 2] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];

                    if (tempSum > maxSum)
                    {
                        row = i;
                        col = j;
                        maxSum = tempSum;
                    }
                }
            }

            Console.WriteLine("Max sum is {0}",maxSum);
            Console.WriteLine("top left element of the area is matrix[{0}, {1}]", row,col);
        }
    }
}
