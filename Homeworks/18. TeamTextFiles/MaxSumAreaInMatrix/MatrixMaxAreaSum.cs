using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class MatrixMaxAreaSum
{
    //Write a program that reads a text file containing a square matrix of numbers 
    //and finds in the matrix an area of size 2 x 2 with a maximal sum of its
    //elements. The first line in the input file contains the size of
    //matrix N. Each of the next N lines contain N numbers separated
    //by space. The output should be a single number in a separate
    //text file. Example:
    //4
    //2 3 3 4
    //0 2 3 4			output: 17
    //3 7 1 2
    //4 3 3 2
    public static int[,] matrix;
    static void Main(string[] args)
    {
        string filePath = "../../Files/matrix.txt";
        FillMatrixFromFile(filePath);
        //print the matrix if needed
        //PrintMatrix(matrix);

        long tempAreaSum = 0;
        long maxAreaSum = long.MinValue;

        for (int i = 0; i < matrix.GetLength(0) - 1; i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                tempAreaSum = matrix[i, j] + matrix[i + 1, j] + matrix[i, j + 1] + matrix[i + 1, j + 1];
                if (tempAreaSum > maxAreaSum)
                    maxAreaSum = tempAreaSum;
            }
        }
        Console.WriteLine("The max sum in area is {0}", maxAreaSum);
    }

    public static void FillMatrixFromFile(string file)
    {
        int matrixSize = 0;
        List<int[]> matrixRows = new List<int[]>();
        using (StreamReader sr = new StreamReader(file))
        {
            int count = 0;
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (count == 0)
                {
                    matrixSize = int.Parse(line);
                    matrix = new int[matrixSize, matrixSize];
                }
                else
                {
                    matrixRows.Add(line.Split(' ').Select(x => int.Parse(x)).ToArray());
                }
                count++;
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = matrixRows[i][j];
                }
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