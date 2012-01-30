using System;
using System.Linq;

namespace Sudoku
{
    class Program
    {
        struct point
        {
            public int x;
            public int y;
            public point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }//45
        public static int[,] board =
        {
            { 5, 3, 0, 0, 7, 0, 0, 0, 0 },
            { 6, 0, 0, 1, 9, 5, 0, 0, 0 },
            { 0, 9, 8, 0, 0, 0, 0, 6, 0 },
            { 8, 0, 0, 0, 6, 0, 0, 0, 3 },
            { 4, 0, 0, 8, 0, 3, 0, 0, 1 },
            { 7, 0, 0, 0, 2, 0, 0, 0, 6 },
            { 0, 6, 0, 0, 0, 0, 2, 8, 0 },
            { 0, 0, 0, 4, 1, 9, 0, 0, 5 },
            { 0, 0, 0, 0, 8, 0, 0, 7, 9 },
        };
        static void Main(string[] args)
        {
            CheckArea(new point(0, 0));
        }

        static bool CheckArea(point topLeft)
        {
            for (int i = topLeft.y; i < topLeft.y + 3; i++)
            {
                for (int j = topLeft.x; j < topLeft.x + 3; j++)
                {
                    Console.Write(board[i, j]);
                    for (int k = 1; k < 10; k++)
                    {
                        
                    }
                }
                Console.WriteLine();
            }

            return true;
        }
    }
}