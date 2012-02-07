using System;
using System.Linq;

class TicTacToe
{
    /// <summary>
    /// code uploaded at:
    /// 
    /// </summary>
    static int[,] board = new int[3, 3]
    {
        { 0, 0, 3, },
        { 1, 1, 0, },
        { 1, 1, 0, }
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

    static void FindNumberOfWins(int row, int col)
    {
        //if X and 0 are even - X will be on the move, because he started first
        int nextDigit = 1;
        if (CountDigit(0) == CountDigit(1))
        {
           nextDigit = 1;
        }
        else
        {
            nextDigit = 0;
        }


        if (CheckForWin(1))
        {
            xWins++;
            return;
        }

        if (CheckForWin(0))
        {
            zWins++;
            return;
        }

        if (CountDigit(3) == 0 && !CheckForWin(1) && !CheckForWin(0))
        {
            draw++;
            return;
        }

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (board[i, j] == 3)
                {
                    //cell is empty - so try recursion

                    board[i, j] = nextDigit;
                    FindNumberOfWins(i, j);
                    //board[i, j] = 0;
                    //FindNumberOfWins(i, j);
                    //board[i, j] = 1;
                    //FindNumberOfWins(i, j);
             
                    
                }
            }
        }
        board[row, col] = 3;

    }

    // Mark back the current cell as free

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