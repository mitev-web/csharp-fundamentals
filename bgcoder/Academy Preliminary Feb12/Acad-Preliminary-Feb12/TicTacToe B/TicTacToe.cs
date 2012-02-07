using System;
using System.Linq;

class TicTacToe
{

    /// <summary>
    /// code uploaded at:
    /// http://ideone.com/4M1Se
    /// </summary>

    static int[,] board = new int[3, 3]
    {
        { 0, 0, 3, },
        { 1, 3, 1, },
        { 3, 3, 3, }
    };

    //1 is X
    //0 is 0
    //3 is empty cell

    static int xWins = 0;
    static int zWins = 0;
    static int draw = 0;

    static void Main(string[] args)
    {
        FindNumberOfWins(0, 0);

        Console.WriteLine(xWins);
        Console.WriteLine(draw);
        Console.WriteLine(zWins);
        
    }

    static void FindNumberOfWins(int row, int col, int nextDigit = 0)
    {
        if (IsOutsideOfBoard(row, col))
            return;

        //we scroll until we find an empty cell
        while (board[row, col] != 3)
        {
            if (++col > 2)
            {
                col = 0;
                row++;
                if (row > 2)
                {
                    //outside of board
                    return;
                }
            }
        }

        //if X and 0 are even - X will be on the move, because he started first
        if (CountDigit(0) == CountDigit(1))
        {
            nextDigit = 1;
        }
        else
        {
            nextDigit = 0;
        }

        board[row, col] = nextDigit;

        if (CheckForWin(1))
        {
            xWins++;
        }

        if (CheckForWin(0))
        {
            zWins++;
      
        }

        if (CountDigit(3) == 0 && !CheckForWin(1) && !CheckForWin(0))
        {
            draw++;
        }

        FindNumberOfWins(row, col - 1, nextDigit); // left
        FindNumberOfWins(row + 1, col, nextDigit); // down

        FindNumberOfWins(row, col + 1, nextDigit); // left
        FindNumberOfWins(row - 1, col, nextDigit); // up

        // Mark back the current cell as free
        board[row, col] = 3;
    }
  
    private static bool IsOutsideOfBoard(int row, int col)
    {
        if (row > 2 || col > 2 || row < 0 || col < 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static int CountDigit(int digit)
    {
        int count = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (board[i, j] == digit)
                {
                    count++;
                }
            }
        }
        return count;
    }

    private static bool CheckForWin(int digit)
    {
        int combinations = 0;
        for (int i = 0; i < 3; i++)
        { //horizontal
            if ((board[i, 0] == board[i, 1]) &&
                (board[i, 1] == board[i, 2]) &&
                (board[i, 2] == digit))
            {
                combinations++;
            }
            //vertical
            if ((board[0, i] == board[1, i]) &&
                (board[1, i] == board[2, i]) &&
                (board[2, i] == digit))
            {
                combinations++;
            }
        }
        //diagonal
        if ((board[0, 0] == board[1, 1]) &&
            (board[1, 1] == board[2, 2]) &&
            (board[2, 2] == digit))
        {
            combinations++;
        }
        //diagonal
        if ((board[2, 0] == board[1, 1]) &&
            (board[1, 1] == board[0, 2]) &&
            (board[0, 2] == digit))
        {
            combinations++;
        }

        if (combinations > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void Print()
    {
        Console.WriteLine();
        Console.WriteLine();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(board[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}