using System;
using System.Linq;

namespace Task07
{
    class Program
    {
        //* Write a program that finds the largest area of equal neighbor elements
        //    in a rectangular matrix and prints its size. Example:

        struct Position
        {
            public int x;
            public int y;

            public Position(int y, int x)
            {
                this.y = y;
                this.x = x;
            }
        }

        public static int[,] matrix =
            {
                { 1, 3, 2, 2, 2, 4 },
                { 3, 3, 3, 2, 4, 4 },
                { 4, 7, 1, 2, 3, 3 },
                { 4, 3, 1, 4, 1, 1 },
                { 4, 3, 3, 1, 4, 1 },
            };

        public static int counter = 0;
        public static int maxCounter = 0;
        public static int maxElementValue = 0;
        public static bool[,] isVisited = null;

        //implementing using BFS
        static void Main(string[] args)
        {
            isVisited = new bool[matrix.GetLength(0), matrix.GetLength(1)];
            int currentElement = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Position p = new Position(i, j);
                    currentElement = matrix[i, j];
                    FindEqualNeighbors(p, currentElement);
                    counter = 0;
                }
            }
            Console.WriteLine("there are  {0} neighbor elements with value {1}", maxCounter, maxElementValue);
        }

        static void FindEqualNeighbors(Position p, int value)
        {
            if (p.y >= matrix.GetLength(0) || p.y < 0 || p.x >= matrix.GetLength(1) || p.x < 0) return;

            if (isVisited[p.y, p.x]) return;

            if (matrix[p.y, p.x] != value)
                return;
            else
            {
                isVisited[p.y, p.x] = true;
                counter++;
                if (maxCounter < counter)
                {
                    maxCounter = counter;
                    maxElementValue = value;
                }
            }
            Position down = new Position(++p.y, p.x);
            Position right = new Position(p.y, ++p.x);
            Position up = new Position(--p.y, p.x);
            Position left = new Position(p.y, --p.x);

            FindEqualNeighbors(down, value);
            FindEqualNeighbors(right, value);
            FindEqualNeighbors(up, value);
            FindEqualNeighbors(left, value);

        }

    }

    
}
