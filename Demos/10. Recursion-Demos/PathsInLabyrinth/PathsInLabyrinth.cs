using System;

class PathsInLabyrinth
{
    static char[,] lab = 
    {
        {' ', ' ', ' ', '*', ' ', ' ', ' '},
        {'*', '*', ' ', '*', ' ', '*', ' '},
        {' ', ' ', ' ', ' ', ' ', ' ', ' '},
        {' ', '*', '*', '*', '*', '*', ' '},
        {' ', ' ', ' ', ' ', ' ', ' ', 'е'},
    };

    static void FindPathToExit(int row, int col)
    {
        if ((col < 0) || (row < 0) || (col >= lab.GetLength(1)) || (row >= lab.GetLength(0)))
        {
            // We are out of the labyrinth -> can't find a path
            return;
        }

        // Check if we have found the exit
        if (lab[row, col] == 'е')
        {
            Console.WriteLine("Found the exit!");
        }

        if (lab[row, col] != ' ')
        {
            // The current cell is not free -> can't find a path
            return;
        }

        // Temporary mark the current cell as visited
        lab[row, col] = 's';

        // Invoke recursion the explore all possible directions
        FindPathToExit(row, col - 1); // left
        FindPathToExit(row - 1, col); // up
        FindPathToExit(row, col + 1); // right
        FindPathToExit(row + 1, col); // down

        // Mark back the current cell as free
        lab[row, col] = ' ';
    }

    static void Main()
    {
        FindPathToExit(0, 0);
    }
}
