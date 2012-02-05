using System;

class PathsBetweenCells
{
    //Task 7
    //Modify the above program to check whether 
    //a path exists between two cells without finding all possible paths. 
    //Test it over an empty 100 x 100 matrix.
    static char[,] matrix = null;
    static bool isComplete = false;

    static void FindNumberOfPaths(int row, int col)
    {
        if (isComplete)
        {
            return;
        }
        if ((col < 0) || (row < 0) || (col >= matrix.GetLength(1)) || (row >= matrix.GetLength(0)))
        {
            return;
        }

        if (matrix[row, col] == 'e')
        {
            isComplete = true;
            Console.WriteLine("Exit Found");
            Print();
            return;
        }

        if (matrix[row, col] != '.')
        {
            // The current cell is not free -> can't find a path
            return;
        }

        // Temporary mark the current cell as visited
        matrix[row, col] = 's';

        if (!isComplete)
            FindNumberOfPaths(row, col - 1); // left
        if (!isComplete)
            FindNumberOfPaths(row - 1, col); // up
        if (!isComplete)
            FindNumberOfPaths(row, col + 1); // right
        if (!isComplete)
            FindNumberOfPaths(row + 1, col); // down

        // Mark back the current cell as free
        matrix[row, col] = ' ';
    }

    static void Main()
    {
        FillMatrix(30);       
        FindNumberOfPaths(0, 0);
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
       
        Console.WriteLine("\n\n\n\n");
    }

    static void FillMatrix(int matrixLenght)
    {
        matrix = new char[matrixLenght, matrixLenght];

        for (int i = 0; i < matrixLenght; i++)
        {
            for (int j = 0; j < matrixLenght; j ++)
            {
                matrix[i, j] = '.';
            }
        }

        Random rand = new Random(11);

        for (int i = 0; i < matrixLenght * 3; i++)
        {
            matrix[rand.Next(matrixLenght), rand.Next(matrixLenght)] = '*';
        }

        matrix[matrixLenght - 1, matrixLenght - 1] = 'e';
    }
}