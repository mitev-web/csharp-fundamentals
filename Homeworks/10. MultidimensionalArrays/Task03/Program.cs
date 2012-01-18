using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task03
{
        //We are given a matrix of strings of size N x M. 
        //Sequences in the matrix we define as sets of several
        //    neighbor elements located on the same line, column 
        //or diagonal. Write a program that finds the longest 
        //    sequence of equal strings in the matrix. Example:

        //ha  fifi ho   hi
        //fo  ha   hi   xx
        //xxx ho   ha   xx
        //
        //answer: ha, ha, ha
    class Program
    {
     public struct Point
        {
           public int y;
           public int x;

            public Point(int y, int x)
            {
                this.y = y;
                this.x = x;
            }
        }

      public static bool[,] isVisited = null;
      public static Random rand = new Random();
      public static string value = "";
      public static int N = 3;
      public static int K = 4;
      public static int counter = 0;
      public static int maxCounter = 0;
      public static string maxElementValue = "";
      public static string lastPosition = "";

      public static string[,] arr = null;

        static void Main(string[] args)
        {
            arr = new string[N,K];
            isVisited = new bool[N, K];

            FillMatrix(arr);
            PrintMatrix(arr);

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Point p = new Point(i, j);
                    value = arr[i, j];

                    FindEqualNeighbors(p, value);
                }
            }

            Console.WriteLine("There are {0} neighbor elements with value {1}",maxCounter,maxElementValue);

        }


        public static void FindEqualNeighbors(Point p, string value, string position = "", string lastPosition = "")
        {
            if (p.y < 0 || p.y >= arr.GetLength(0) || p.x < 0 || p.x >= arr.GetLength(1)) return;

            if (isVisited[p.y, p.x]) return;

            if (position.Length > 0 && position != lastPosition) return;
 
            if (arr[p.y, p.x] != value)
                return;
            else
            {
                isVisited[p.y,p.x] = true;
                counter++;
                if (maxCounter < counter)
                {
                    maxCounter++;
                    maxElementValue = value;
                }
            }

            Point up = new Point(--p.y, p.x);
            Point down = new Point(++p.y, p.x);
            Point left = new Point(p.y, --p.x);
            Point right = new Point(p.y, ++p.x);

            //Point downLeft = new Point(++p.y, --p.x);
            //Point downRight = new Point(++p.y, ++p.x);

            lastPosition = position;

            FindEqualNeighbors(up, value, "vert", lastPosition);
            FindEqualNeighbors(down, value, "vert", lastPosition);
            FindEqualNeighbors(left, value, "horz", lastPosition);
            FindEqualNeighbors(right, value, "horz", lastPosition);

            //FindEqualNeighbors(downLeft, value, "diag1", lastPosition);
            //FindEqualNeighbors(downRight, value, "diag2", lastPosition);

        }


        public static void FillMatrix(string[,] arr) 
        {
           int N = arr.GetLength(0);
           int K = arr.GetLength(1);
            for (int i = 0; i < N; i++) for (int j = 0; j < K; j++) arr[i, j] = RandomString(2); 
        
        }


        public static string RandomString(int size)
        {

            string letters = "AB";
            char[] buff = new char[size];

            for(int i=0; i< size;i++)
            {
                buff[i] =  letters[rand.Next(letters.Length)];
            }

            return new string(buff);
        }

        private static void PrintMatrix(string[,] matrix)
        {
            int n = matrix.GetLength(0);
            int k = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    Console.Write("{0,3}", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
