using System;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku
{
    class Program
    {
        //public static int[,] board =
        //{ //15726
        //    { 9, 0, 0, 0, 0, 0, 0, 0, 0 },
        //    { 0, 7, 0, 3, 0, 0, 0, 0, 0 },
        //    { 5, 1, 3, 4, 0, 0, 7, 2, 0 },
        //    { 0, 4, 0, 0, 1, 0, 3, 0, 6 },
        //    { 0, 2, 0, 5, 6, 3, 0, 9, 0 },
        //    { 6, 0, 5, 0, 7, 0, 0, 8, 0 },
        //    { 0, 9, 7, 0, 0, 8, 5, 6, 4 },
        //    { 0, 0, 0, 0, 0, 5, 0, 7, 0 },
        //    { 0, 0, 0, 0, 0, 0, 0, 0, 3 },
        //};
          static int[,] board = new int[9, 9];

        public static string[,] boardStr =
        {
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "" },
        };

        static void Main(string[] args)
        {
            FillBoardFromInput();
            //CopyMatrix(board, boardStr);
            //OptimizeBoard();
            try
            {
                FillBoard(0, 0);
            }
            catch (Exception){}

            Print(board);
        }

        private static void FillBoard(int row, int col)
        {
            // Skip cells which are not empty
            while (board[row, col] != 0)
            {
                if (++col > 8)
                {
                    col = 0;
                    row++;
                }

                if (row > 8)
                    break;
            }
         
            // Find a valid number for the empty cell
            for (int num = 1; num < 10; num++)
            {
                if (NumberIsValidForPosition(row, col, num))
                {
                    board[row, col] = num;

                    // Delegate work on the next cell to a recursive call
                    if (col < 8)
                    {
                        FillBoard(row, col + 1);
                    }
                    else
                    {
                        FillBoard(1+row, 0);
                    }
                }
            }

            // No valid number was found, clean up and return to caller
            board[row, col] = 0;
        }

        private static bool NumberIsValidForPosition(int row, int col, int num)
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

        static void FillBoardFromInput()
        {
            for (int i = 0; i < 9; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < 9; j++)
                {
                    if (line[j] == '-')
                    {
                        board[i, j] = 0;
                    }
                    else
                    {
                        board[i, j] = int.Parse(line[j].ToString());
                    }
                }
            }
        }

        static void OptimizeBoard()
        {
            bool needOptimization = true;
            while (needOptimization)
            {
                needOptimization = false;
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (boardStr[i, j].Length > 1)
                        {
                            List<int> numbers = new List<int>();
                            numbers.AddRange(OptimizeBox(i, j));
                            numbers.AddRange(OptimizeRow(i));
                            numbers.AddRange(OptimizeColumn(j));

                            foreach (char item in string.Join("", numbers.Select(x => x.ToString()).Distinct().ToArray()))
                            {
                                if (boardStr[i, j].Contains(item))
                                {
                                    int index = boardStr[i, j].IndexOf(item);
                                    if (boardStr[i, j].Length > 1)
                                    {
                                        boardStr[i, j] = boardStr[i, j].Remove(index, 1);
                                    }
                                    needOptimization = true;
                                }
                            }
                            numbers.Clear();
                        }
                    }
                }
            }
            ImportStringData();
        }

        static void ImportStringData()
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (boardStr[row, col].Length == 1)
                    {
                        board[row, col] = int.Parse(boardStr[row, col]);
                    }
                }
            }
        }
        
        static List<int> OptimizeBox(int row, int col)
        {
            row = (row / 3) * 3;
            col = (col / 3) * 3;

            List<int> numbers = new List<int>();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (boardStr[row + i, col + j].Length == 1)
                    {
                        numbers.Add(int.Parse(boardStr[i, j]));
                    }
                }
            }
            return numbers;
        }

        static List<int> OptimizeRow(int row)
        {
            List<int> numbers = new List<int>();
            for (int i = 0; i < 9; i++)
            {
                if (boardStr[row, i].Length == 1)
                {
                    numbers.Add(int.Parse(boardStr[row, i]));
                }
            }
            return numbers;
        }

        static List<int> OptimizeColumn(int column)
        {
            List<int> numbers = new List<int>();
            for (int i = 0; i < 9; i++)
            {
                if (boardStr[i, column].Length == 1)
                {
                    numbers.Add(int.Parse(boardStr[i, column]));
                }
            }
            return numbers;
        }

        static void CopyMatrix(int[,] arr, string[,] strArr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] != 0)
                    {
                        strArr[i, j] = arr[i, j].ToString();
                    }
                    else
                    {
                        strArr[i, j] = "123456789";
                    }
                }
            }
        }

        static void Print<T>(T[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                if (i % 3 == 0)
                {
                    //Console.WriteLine();
                }
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write("{0}", arr[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}