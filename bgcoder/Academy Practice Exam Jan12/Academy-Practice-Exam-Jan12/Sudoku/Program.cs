using System;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku
{
    class Program
    {
        public static int[,] board =
        {
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
       //static int[,] board = new int[9, 9];

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
        public static int[,] Board
        {
            get
            {
                return board;
            }
            set
            {
                board = value;
            }
        }

        static void Main(string[] args)
        {
            //FillBoard();
            CopyMatrix(board, boardStr);

            for (int i = 0; i < 9; i++)
            {
                OptimizeBoard();
                CheckForSingletons();
            }

           // FillEmptyCells();


            Print(boardStr);

        }

        static void FillEmptyCells()
        {
            for (int i = 0; i < 9; i++)
            {
                FillMissingCellInRows(i);
            }
                
       
        
        }

        static void CheckForSingletons()
        {
            for (int i = 0; i < 9; i++)
            {
                CheckRowForSingletons(i);
                CheckColumnForSingletons(i);
                CheckAreaForSingletons(i);
            }

        }

        static void CheckRowForSingletons(int row)
        {
            Dictionary<int, int> keyValue = new Dictionary<int, int>();
            Dictionary<int, int> keyColumn = new Dictionary<int, int>();

            for (int col = 0; col < 9; col++)
            {
                if (boardStr[row, col].Length > 1)
                {
                    foreach (char item in boardStr[row, col])
                    {
                        int num = int.Parse(item.ToString());

                        if (keyValue.ContainsKey(num))
                        {
                            keyValue[num]++;
                        }
                        else
                        {
                            keyValue.Add(num, 1);
                            keyColumn.Add(num, col);
                        }
                    }
                }
            }
            foreach (KeyValuePair<int, int> item in keyValue)
            {
                if (item.Value == 1)
                {
                    //Console.WriteLine("{0} added at pos: {1} {2})", item.Key.ToString(), row, keyColumn[item.Key]);
                    boardStr[row, keyColumn[item.Key]] = item.Key.ToString();
                }
            }
        }

        static void CheckAreaForSingletons(int area)
        {
            int row = 0;
            int col = 0;

            switch (area)
            {
                case 0:
                    row = 0;
                    col = 0;
                    break;
                case 1:
                    row = 0;
                    col = 3;
                    break;
                case 2:
                    row = 0;
                    col = 6;
                    break;
                case 3:
                    row = 3;
                    col = 0;
                    break;
                case 4:
                    row = 3;
                    col = 3;
                    break;
                case 5:
                    row = 3;
                    col = 6;
                    break;
                case 6:
                    row = 6;
                    col = 0;
                    break;
                case 7:
                    row = 6;
                    col = 3;
                    break;
                case 8:
                    row = 6;
                    col = 6;
                    break;
            }
            Dictionary<int, int> keyValue = new Dictionary<int, int>();
            Dictionary<int, int> keyRow = new Dictionary<int, int>();
            Dictionary<int, int> keyCol = new Dictionary<int, int>();
            for (int i = row; i < row + 3; i++)
            {
                for (int j = col; j < col + 3; j++)
                {
                    if (boardStr[i, j].Length > 1)
                    {
                        foreach (char item in boardStr[row, col])
                        {
                            int num = int.Parse(item.ToString());

                            if (keyValue.ContainsKey(num))
                            {
                                keyValue[num]++;
                            }
                            else
                            {
                                keyValue.Add(num, 1);
                                keyRow.Add(num, row);
                                keyCol.Add(num, col);
                            }
                        }
                    }
                }
            }
            foreach (KeyValuePair<int, int> item in keyValue)
            {
                if (item.Value == 1)
                {
                    Console.WriteLine("{0} added at pos: {1} {2})", item.Key.ToString(), keyRow[item.Key], keyCol[item.Key]);
                    boardStr[keyRow[item.Key], keyCol[item.Key]] = item.Key.ToString();
                }
            }
        }

        static void CheckColumnForSingletons(int col)
        {
            Dictionary<int, int> keyValue = new Dictionary<int, int>();
            Dictionary<int, int> keyRow = new Dictionary<int, int>();

            for (int row = 0; row < 9; row++)
            {
                if (boardStr[row, col].Length > 1)
                {
                    foreach (char item in boardStr[row, col])
                    {
                        int num = int.Parse(item.ToString());

                        if (keyValue.ContainsKey(num))
                        {
                            keyValue[num]++;
                        }
                        else
                        {
                            keyValue.Add(num, 1);
                            keyRow.Add(num, row);
                        }
                    }
                }
            }
            foreach (KeyValuePair<int, int> item in keyValue)
            {
                if (item.Value == 1)
                {
                    //Console.WriteLine("{0} added at pos: {1} {2})", item.Key.ToString(), keyRow[item.Key], col);
                    boardStr[keyRow[item.Key], col] = item.Key.ToString();
                }
            }
        }

        static void FillMissingCellInRows(int row)
        {
            int tempRow = 0;
            int tempCol = 0;
            int sum = 0;
            for (int col = 0; col < 9; col++)
            {
                if (boardStr[row, col] == "")
                {
                    tempCol = col;
                    tempRow = row;
                }
                else
                {
                    Console.WriteLine("num is is {0}", int.Parse(boardStr[row, col]));
                    sum += int.Parse(boardStr[row, col]);
                }
            }
            Console.WriteLine("the number should be {0}",45 - sum);
            //boardStr[tempRow, tempCol] = (45 - sum).ToString();
        }

        static void FillBoard()
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
            while(needOptimization){
                needOptimization = false;
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (boardStr[i, j].Length > 1)
                        {
                            List<int> numbers = new List<int>();
                            numbers.AddRange(OptimizeRow(i));
                            numbers.AddRange(OptimizeColumn(j));
                            numbers.AddRange(OptimizeArea(i, j));

                            foreach (char item in string.Join("", numbers.Select(x => x.ToString()).Distinct().ToArray()))
                            {
                                if (boardStr[i, j].Contains(item))
                                {
                                    int index = boardStr[i, j].IndexOf(item);
              
                                    boardStr[i, j] = boardStr[i, j].Remove(index, 1);
                    
                                
                                    needOptimization = true;
                                }
                            }
                        }
                    }
                }
            }
        }
        
        static List<int> OptimizeArea(int row, int col)
        {
            //get top left index of the area
            //there are 9 cases (areas)
            if (row < 3 && col < 3)
            {
                row = 0;
                col = 0;
            }
            if (row < 3 && col > 2 && col < 6)
            {
                row = 0;
                col = 3;
            }
            if (row < 3 && col > 5 && col < 9)
            {
                row = 0;
                col = 6;
            }
            if (row > 2 && row < 6 && col < 3)
            {
                row = 3;
                col = 0;
            }
            if (row > 2 && row < 6 && col > 2 && col < 6)
            {
                row = 3;
                col = 3;
            }
            if (row > 2 && row < 6 && col > 5 && col < 9)
            {
                row = 3;
                col = 6;
            }
            if (row > 5 && row < 9 && col < 3)
            {
                row = 6;
                col = 0;
            }
            if (row > 5 && row < 9 && col > 2 && col < 6)
            {
                row = 6;
                col = 3;
            }
            if (row > 5 && row < 9 && col > 5 && col < 9)
            {
                row = 6;
                col = 6;
            }

            List<int> numbers = new List<int>();
            //traverse the area
            for (int i = row; i < row + 3; i++)
            {
                for (int j = col; j < col + 3; j++)
                {
                    if (boardStr[i, j].Length == 1)
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
                    Console.Write("{0} \t", arr[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}