using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B_Sudoku
{
    class Program
    {
        public static int[,] board =
        { //15726
            { 9, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 7, 0, 3, 0, 0, 0, 0, 0 },
            { 5, 1, 3, 4, 0, 0, 7, 2, 0 },
            { 0, 4, 0, 0, 1, 0, 3, 0, 6 },
            { 0, 2, 0, 5, 6, 3, 0, 9, 0 },
            { 6, 0, 5, 0, 7, 0, 0, 8, 0 },
            { 0, 9, 7, 0, 0, 8, 5, 6, 4 },
            { 0, 0, 0, 0, 0, 5, 0, 7, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 3 },
        };
        static void Main(string[] args)
        {

            try
            {
                FillBoard(0, 0);
            }
            catch (Exception ex)
            {
            }
            Print(board);
        }

        private static void FillBoard(int row, int col)
        {
            if (row > 8)
                throw new Exception("Solution found");
            else
            {
                // Skip cells which are not empty
                while (board[row, col] != 0)
                {
                    if (++col > 8)
                    {
                        col = 0 ;
                        row++ ;
 
                        // Throw an exception to stop the process if the puzzle is solved
                        if (row > 8)
                            throw new Exception("Solution found");
                    }
                }
 
                // Find a valid number for the empty cell
                for (int num = 1; num < 10; num++)
                {
                    if (NumberIsValidForPosition(row,col,num))
                    {
                        board[row, col] = num;
 
                        // Delegate work on the next cell to a recursive call
                        if (col < 8)
                            FillBoard(row, col + 1) ;
                        else
                            FillBoard(row + 1, 0) ;
                    }
                }
 
                // No valid number was found, clean up and return to caller
                board[row, col] = 0;
            }
        }

        private static bool NumberIsValidForPosition(int row, int col,int num)
        {

            return NumberIsValidForRow(row, num) && NumberIsValidForCol(col, num) && NumberIsValidForBox(row, col, num);
        }
 
        private static bool NumberIsValidForRow(int row, int num)
        {
            for (int col = 0; col < 9; col++)
                if (board[row, col] == num)
                    return false;
 
            return true;
        }

        private static bool NumberIsValidForCol(int col, int num)
        {
            for (int row = 0; row < 9; row++)
                if (board[row, col] == num)
                    return false;
            return true;
        }

        private static bool NumberIsValidForBox(int row, int col, int num)
        {
            row = (row / 3) * 3;
            col = (col / 3) * 3;
 
            for (int r = 0; r < 3; r++)
                for (int c = 0; c < 3; c++)
                    if (board[row + r, col + c] == num)
                        return false;
 
            return true;
        }

        static void Print<T>(T[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                if (i % 3 == 0)
                {
                    Console.WriteLine();
                }
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write("{0} \t", arr[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}