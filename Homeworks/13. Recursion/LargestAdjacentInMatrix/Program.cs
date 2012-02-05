using System;

class PathsBetweenCells
{
    //Task 8
    //Write a program to find the largest connected area of adjacent empty cells in a matrix.
    static char[,] matrix = null;

    static int maxPathCount = 0;

    static void Main()
    {
        FillMatrix(30);
        FindNumberOfPaths(0, 0, 0);
        Print();
        Console.WriteLine("Number of adjacent cells is {0}", maxPathCount);
    }

    static void FindNumberOfPaths(int row, int col, int pathCount)
    {
        if ((col < 0) || (row < 0) || (col >= matrix.GetLength(1)) || (row >= matrix.GetLength(0)))
        {
            if (pathCount > maxPathCount)
                maxPathCount = pathCount;
            return;
        }

        if (matrix[row, col] != ' ')
        {
            if (pathCount > maxPathCount)
                maxPathCount = pathCount;
            return;
        }

        pathCount++;
        // Temporary mark the current cell as visited
        matrix[row, col] = 's';

        FindNumberOfPaths(row, col - 1, pathCount); // left
        FindNumberOfPaths(row - 1, col, pathCount); // up
        FindNumberOfPaths(row, col + 1, pathCount); // right
        FindNumberOfPaths(row + 1, col, pathCount); // down
    }

    static void Print()
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write("{0}", matrix[i, j]);
            }
            Console.WriteLine();
        }

        Console.WriteLine();
    }

    static void FillMatrix(int matrixLenght)
    {
        matrix = new char[matrixLenght, matrixLenght];

        for (int i = 0; i < matrixLenght; i++)
        {
            for (int j = 0; j < matrixLenght; j++)
            {
                matrix[i, j] = ' ';
            }
        }

        Random rand = new Random(11);

        for (int i = 0; i < matrixLenght * 3; i++)
        {
            matrix[rand.Next(matrixLenght), rand.Next(matrixLenght)] = '*';
        }
    }
}