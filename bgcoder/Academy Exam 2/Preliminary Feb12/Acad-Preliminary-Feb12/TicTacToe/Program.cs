using System;
using System.Linq;

namespace TicTacToe
{
    class Program
    {
        static int[,] board = new int[3, 3]
        {
            { 0, 0, 3, },
            { 1, 3, 1, },
            { 3, 3, 3, }
        };
        static int xComb = 0;
        static int evenComb = 0;
        static int zeroComb = 0;
        static int startsWith = 0;
   

        static void Main(string[] args)
        {

        
                CountWinners(0, 0,1);

            
            Console.WriteLine(xComb);
            Console.WriteLine(evenComb);
            Console.WriteLine(zeroComb);
        }
  
        private static void CountWinners(int row, int col, int startsWith)
        {

            if (CheckForWin(0) > 0)
            {
                zeroComb += 1;
            }

            if (CheckForWin(1) > 0)
            {
                xComb += 1;
            }
          
 
        
            if (row > 2)
            {
              
                if (CheckForWin(0) == 0 && CheckForWin(1) == 0)
                {
                    evenComb++;
                }
                // throw new Exception("Solution found");
            }
            else
            {
                // Skip cells which are not empty
                while (board[row, col] != 3)
                {
                    if (++col > 2)
                    {
                        col = 0;
                        row++;

                        // Throw an exception to stop the process if the puzzle is solved
                        if (row > 2)
                        {
                            if (CheckForWin(0) == 0 && CheckForWin(1) == 0)
                            {
                                evenComb++;
                            }
                            throw new Exception("Solution found");
                        }
                    }
                }

                for (int num = 0; num < 2; num++)
                {

                    if (CountDigit(0) == CountDigit(1))
                    {
                        startsWith = 1;
                    }
                    else
                    {
                        startsWith = 0;
                    }
                    board[row, col] = startsWith;
                   


                    // Delegate work on the next cell to a recursive call
                    if (col < 2)
                        CountWinners(row, col + 1,startsWith);
                    else
                        CountWinners(row + 1, 0, startsWith);
                }
                // No valid number was found, clean up and return to caller
                board[row, col] = 3;
            }
        }
  
        private static int CheckForWin(int digit)
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
            return combinations;
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
    }
}