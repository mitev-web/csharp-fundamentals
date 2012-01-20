using System;

class AllPathsInLabyrinth
{
    static char[,] lab = 
    {
        {' ', ' ', ' ', '*', ' ', ' ', ' '},
        {'*', '*', ' ', '*', ' ', '*', ' '},
        {' ', ' ', ' ', ' ', ' ', ' ', ' '},
        {' ', '*', '*', '*', '*', '*', ' '},
        {' ', ' ', ' ', ' ', ' ', ' ', 'е'},
    };

    static char[] path = new char[lab.GetLength(0) * lab.GetLength(1)];
    static int position = 0;

    static void FindPathToExit(int row, int col, char direction)
    {
        if ((col < 0) || (row < 0) || (col >= lab.GetLength(1)) || (row >= lab.GetLength(0)))
        {
            // We are out of the labyrinth -> can't find a path
            return;
        }

        // Append the current direction to the path
        path[position] = direction;
        position++;

        // Check if we have found the exit
        if (lab[row, col] == 'е')
        {
            Console.WriteLine(position);
            PrintPath(path, 1, position-1);
        }

        if (lab[row, col] == ' ')
        {
            // Temporary mark the current cell as visited
            lab[row, col] = 's';

            // Recursively explore all possible directions
            FindPathToExit(row, col - 1, 'L'); // left
            FindPathToExit(row - 1, col, 'U'); // up
            FindPathToExit(row, col + 1, 'R'); // right
            FindPathToExit(row + 1, col, 'D'); // down


            // Mark back the current cell as free
            lab[row, col] = ' ';
        }

        // Remove the last direction from the path
        position--;
    }

    static void PrintPath(char[] path, int startPos, int endPos) {
	    Console.Write("Found path to the exit: ");
        Console.WriteLine(position);
        for (int pos = startPos; pos <= endPos; pos++)
        {
            Console.Write(path[pos]);
        }
        Console.WriteLine();
    }

    static void Main()
    {
        FindPathToExit(0, 0, 'S');
    }
}
