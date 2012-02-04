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
        static string[,] matrix = new string[5, 5];

        //public static string[,] matrix =
        //    {
        //        { "A", "A", "A", "A", "A", "A" },
        //        { "A", "A", "A", "A", "A", "A" },
        //        { "A", "A", "A", "A", "B", "A" },
        //        { "A", "A", "A", "A", "B", "A" },
        //        { "A", "A", "A", "A", "B", "A" },
        //    };
        
        static int width = matrix.GetLength(1);
        static int height = matrix.GetLength(0);
   
        static void Main()
        {
            FillMatrix(matrix);
            PrintMatrix(matrix);

            int longest = CheckForLongestEqualSeq();

            Console.WriteLine(longest);
        }
  
        private static int CheckForLongestEqualSeq()
        {
            int temp = 0;
            int max = 0;

            for (int col = 0; col < width; col++)
            {
                temp = CheckColForLongest(col);
                if (temp > max)
                    max = temp;
            }

            for (int row = 0; row < height; row++)
            {
                temp = CheckRowForLongest(row);
                if (temp > max)
                    max = temp;
            }
            temp = CheckLeftDiagonalForLongestEqual();
            if (temp > max)
                max = temp; 

            return max;
        }
        //it makes mistakes on diagonals
        private static int CheckLeftDiagonalForLongestEqual()
        {
            int temp = 1;
            int max = 0;
            int row = 0;
            int col = 0;
            int count = 0;
            
            while (row < height - 1 && col < width - 1)
            {
                if (matrix[row, col] == matrix[row + 1, col + 1])
                {
                    temp++;
                    Console.WriteLine(temp);
                }
                else
                {
                    temp = 1;
                }

                if (temp > max)
                {
                    max = temp;
                }

                row += count;
                col += count;

                count++;
            }
            Console.WriteLine("longest diagonal {0}", max);
            return max;
        }
  
        private static int CheckRowForLongest(int row)
        {
            int temp = 1;
            int max = 0;
            for (int col = 0; col < width - 1; col++)
            {
                if (matrix[row, col] == matrix[row, col + 1])
                {
                    temp++;
                }
                else
                {
                    temp = 1;
                }
                if (temp > max){
                    max = temp;
                }
            }
            return max;
        }
  
        private static int CheckColForLongest(int col)
        {
            int temp = 1;
            int max = 0;
            for (int row = 0; row < height - 1; row++)
            {
                if (matrix[row, col] == matrix[row + 1, col])
                {
                    temp++;
                }
                else
                {
                    temp = 1;
                }
                if (temp > max){
                    max = temp;
                }
            }
            return max;
        }

        public static void FillMatrix(string[,] arr) 
        {
            int N = arr.GetLength(0);
            int K = arr.GetLength(1);
            for (int i = 0; i < N; i++)
                for (int j = 0; j < K; j++)
                    arr[i, j] = RandomString(2); 
        }

        public static string RandomString(int size)
        {
            string letters = "AB";
            char[] buff = new char[size];

            for (int i = 0; i < size;i++)
            {
                byte[] seed = Guid.NewGuid().ToByteArray();
                Random rand = new Random(BitConverter.ToInt32(seed, 0)); 
                buff[i] = letters[rand.Next(letters.Length)];
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