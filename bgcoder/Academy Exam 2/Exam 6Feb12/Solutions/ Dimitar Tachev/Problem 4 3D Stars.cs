using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TASK44
{
    class Program
    {
        static List<char[,]> cubuid = new List<char[,]>();
        static int col;
        static int row;
        static int side;
        static int numberOfStars = 0;
        static Dictionary<char, int> colorStars = new Dictionary<char, int>(24);
        static void Main(string[] args)
        {
            InizializeDictionary();
            ReadCubuid();
         //   PrintKubuid();
            Solve();
            Console.WriteLine(numberOfStars);
            PrintDictionary();
        }

        private static void Solve()
        {
            for (int i = 1; i < row-1; i++)
            {
                for (int j = 1; j < side-1; j++)
                {
                    for (int k = 1; k < col-1; k++)
                    {
                        CheckForStar(k, i, j);
                    }
                }
            }
        }

        private static void CheckForStar(int currCol, int currRow, int currSide)
        {
            if (cubuid[currSide][currRow, currCol] == cubuid[currSide - 1][currRow, currCol] //UP 
                && cubuid[currSide][currRow, currCol] == cubuid[currSide + 1][currRow, currCol] //DOWN
                && cubuid[currSide][currRow, currCol] == cubuid[currSide][currRow, currCol + 1] //Right
                && cubuid[currSide][currRow, currCol] == cubuid[currSide][currRow, currCol - 1] //Left
                && cubuid[currSide][currRow, currCol] == cubuid[currSide][currRow + 1, currCol] //Out
                && cubuid[currSide][currRow, currCol] == cubuid[currSide][currRow - 1, currCol]) //In
            {
                colorStars[cubuid[currSide][currRow, currCol]]++;
                numberOfStars++;
            }
        }
        private static void InizializeDictionary()
        {
            for (char i = 'A'; i <= 'Z'; i++)
            {
                colorStars.Add(i, 0);
            }
        }
        private static void PrintDictionary()
        {
            for (char i = 'A'; i <= 'Z'; i++)
            {
                if (colorStars[i]>0)
                {
                      Console.WriteLine(i.ToString() + " " + colorStars[i]);
                }
            }
        }
        private static void ReadCubuid()
        {
            string[] tempLine = Console.ReadLine().Split(' ');
            char[] tempRow;
            col = int.Parse(tempLine[0]);
            row = int.Parse(tempLine[1]);
            side = int.Parse(tempLine[2]);
            tempRow = new char[col];
            for (int i = 0; i < side; i++)
            {
                cubuid.Add(new char[row, col]);
            }
            for (int i = 0; i < row; i++)
            {
                tempLine = Console.ReadLine().Split(' ');
                for (int j = 0; j < side; j++)
                {
                    tempRow = tempLine[j].Trim().ToCharArray();
                    for (int k = 0; k < col; k++)
                    {
                        cubuid[j][i, k] = tempRow[k];
                    }
                }
            }
        }
        private static void PrintKubuid()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < side; j++)
                {
                    for (int k = 0; k < col; k++)
                    {
                        Console.Write(cubuid[j][i, k] + " ");
                    }
                    if (j != side - 1)
                    {
                        Console.Write("| ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}

/*
7 4 3
BRYYYYY RYYYYGY YRYYYYY
YYYGBGY YYYYGGG YYYGGGY
RYBYGYY RYYYYGY RYBYGBB
RYBYGYY RBYYGYY RYBYGBB
 */
