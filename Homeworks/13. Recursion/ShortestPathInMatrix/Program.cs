using System;

class PathsInLabyrinth
{
    static char[,] lab = 
    {
        { ' ', ' ', ' ', '*', ' ', ' ', ' ' },
        { '*', '*', ' ', '*', ' ', '*', ' ' },
        { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
        { ' ', '*', '*', '*', '*', '*', ' ' },
        { ' ', ' ', ' ', ' ', ' ', ' ', 'e' },
    };
    static int minPathLenght = 0;

    static void Main()
    {
        FindPathToExit(0, 0, 0);
        Console.WriteLine();
        Console.WriteLine("The Minimum Path to Target is {0}", minPathLenght);
    }

    static void FindPathToExit(int row, int col, int pathCount)
    {
        if ((col < 0) || (row < 0) || (col >= lab.GetLength(1)) || (row >= lab.GetLength(0)))
        {
            // We are out of the labyrinth -> can't find a path
            return;
        }
   
        // Check if we have found the exit
        if (lab[row, col] == 'e')
        {
            if (minPathLenght == 0)
            {
                minPathLenght = pathCount;
            }
            else if (minPathLenght > pathCount)
            {
                minPathLenght = pathCount;
            }
            Print(pathCount);
        }

        if (lab[row, col] != ' ')
        {
            // The current cell is not free -> can't find a path
            return;
        }
        pathCount++;
        // Temporary mark the current cell as visited
        lab[row, col] = 's';

        // Invoke recursion the explore all possible directions
        FindPathToExit(row, col - 1, pathCount); // left
        FindPathToExit(row - 1, col, pathCount); // up
        FindPathToExit(row, col + 1, pathCount); // right
        FindPathToExit(row + 1, col, pathCount); // down

        // Mark back the current cell as free
        lab[row, col] = ' ';
    }

    static void Print(int pathCount)
    {
        Console.WriteLine("Number of steps {0}", pathCount);
        for (int i = 0; i < lab.GetLength(0); i++)
        {
            for (int j = 0; j < lab.GetLength(1); j++)
            {
                Console.Write("{0}", lab[i, j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}