using System;
using System.Linq;

namespace Task07.A_Traversal_Matrix_DFS_BFS
{
    class Program
    {
        static int counter = 0;
        static int largestAreaOfEqualNumber = 0;
        static bool[,] isVisited = null;

        //* Write a program that finds the largest area of equal neighbor elements
        //in a rectangular matrix and prints its size. Example:
        //Hint: you can use the algorithm "Depth-first search" or "Breadth-first search"
        //    (find them in Wikipedia).



        static void Main(string[] args)
        {
            int[,] matrix =
            {
                { 1, 3, 2, 2, 2, 4 },
                { 3, 3, 3, 2, 4, 4 },
                { 4, 7, 1, 2, 3, 3 },
                { 4, 3, 1, 1, 1, 1 },
                { 4, 3, 3, 1, 1, 1 },
            };

            int currentElement = 0;
            isVisited = new bool[matrix.GetLength(0), matrix.GetLength(1)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    currentElement = matrix[i, j];

                    FindValidEqualNeighborElement(matrix, i, j, currentElement);
                    counter = 0;
                }
            }

            Console.WriteLine(largestAreaOfEqualNumber);
        }

        static void FindValidEqualNeighborElement(int[,] matrix, int row, int col, int element)
        {
            if ((row >= matrix.GetLength(0)) || (row < 0) ||
                ((col >= matrix.GetLength(1)) || (col < 0)))
            {
                return;
            }

            if (isVisited[row, col])
            {
                return;
            }

            if (matrix[row, col] != element)
            {
                return;
            }

            if (matrix[row, col] == element)
            {
                // Set this row and this column as visited
                isVisited[row, col] = true;

                counter++;
            }

            FindValidEqualNeighborElement(matrix, row + 1, col, element);
            FindValidEqualNeighborElement(matrix, row, col + 1, element);
            FindValidEqualNeighborElement(matrix, row - 1, col, element);
            FindValidEqualNeighborElement(matrix, row, col - 1, element);

            if (counter > largestAreaOfEqualNumber)
            {
                largestAreaOfEqualNumber = counter;
            }
        }
    }
}
