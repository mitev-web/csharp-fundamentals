using System;

class PathsBetweenCells
{

//Task 6
//We are given a matrix of passable and non-passable cells. 
//Write a recursive program for finding all paths between two cells in the matrix.





    static char[,] matix = 
    {
        { ' ', ' ', ' ', '*', ' ', ' ', ' ' },
        { '*', '*', ' ', '*', ' ', '*', ' ' },
        { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
        { ' ', '*', '*', '*', '*', '*', ' ' },
        { ' ', ' ', ' ', ' ', ' ', ' ', 'e' },
    };
    static int numberOfPaths = 0;

    static void FindNumberOfPaths(int row, int col)
    {
        if ((col < 0) || (row < 0) || (col >= matix.GetLength(1)) || (row >= matix.GetLength(0)))
        {
            return;
        }

        if (matix[row, col] == 'e')
        {
            numberOfPaths++;
            Print();
        }

        if (matix[row, col] != ' ')
        {
            // The current cell is not free -> can't find a path
            return;
        }

        // Temporary mark the current cell as visited
        matix[row, col] = 's';

        FindNumberOfPaths(row, col - 1); // left
        FindNumberOfPaths(row - 1, col); // up
        FindNumberOfPaths(row, col + 1); // right
        FindNumberOfPaths(row + 1, col); // down

        // Mark back the current cell as free
        matix[row, col] = ' ';
    }

    static void Main()
    {
        FindNumberOfPaths(0, 0);
        Console.WriteLine();
        Console.WriteLine("The Number of paths is {0}", numberOfPaths);
      
    }

    static void Print()
    {

        for (int i = 0; i < matix.GetLength(0); i++)
        {

            for (int j = 0; j < matix.GetLength(1); j++)
            {
                Console.Write("{0}", matix[i, j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();

    }
}