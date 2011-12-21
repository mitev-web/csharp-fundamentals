using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task25_d
{
    class Program
    {
        static void Main(string[] args)
        {
            //fill in ma3x like the following
            //for N=4
            //10 11 12 13
            // 9  2  3 14
            // 8  1  4 15
            // 7  6  5 16

            Console.WriteLine("Enter size of the matrix (N)");
            int N = new int();
            int.TryParse(Console.ReadLine(), out N);
            int[,] matrix = new int[N, N];

            PopulateMatrix(matrix);
            PrintMatrix(matrix);
        }

        private static void PopulateMatrix(int[,] matrix)
        {
            int positionX = new int();
            int positionY = new int();
            int N = matrix.GetLength(0);

            if (N % 2 == 1)
            {
                positionX = (N / 2);
                positionY = N / 2;
            }
            else
            {
                positionX = N / 2 - 1;
                positionY = N / 2;
            }


            int direction = 0;
            int currentStep = -1;
            int stepChange = 0;

            matrix[positionY, positionX] = 1;

            for (int i = 2; i <= N * N; i++)
            {
                currentStep++;

                switch (direction % 4)
                {
                    case 3:
                        positionX--;
                        break;

                    case 0://up
                        positionY--;
                        break;
                    case 1://right
                        positionX++;
                        break;
                    case 2://down
                        positionY++;
                        break;
                }


                if (currentStep == stepChange)
                {
                    currentStep = -1;
                    direction++;

                    if (direction % 2 == 0)
                    {
                        stepChange++;
                    }
                }
                matrix[positionY, positionX] = i;

            }
        }

        private static void PrintMatrix(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("{0,3}", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
