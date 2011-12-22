using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task01.C
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that fills and prints a matrix of size (n, n) as shown below:
            //(examples for n = 4)

            //7 11  14 16
            //4  8  12 15
            //2  5  9  13
            //1  3  6  10

            int N = int.Parse(Console.ReadLine());

            int direction = 0;
            int[,] arr = new int[N, N];

            int stepChange = 4;
            int currentStep = 0;
            int savePosX = 0;
            int savePosY = N - 1;
            int positionX = 0;
            int positionY = N - 1;

            arr[positionY, positionX] = 1;

            for (int i = 2; i < 6; i++)
            {

                currentStep++;
                switch (direction % 2)
                {
                    case 0://up or right
                        if (positionY == 0)
                        {
                            positionX = savePosX + 1;
                            savePosX = positionX;
                        }
                        else
                        {
                            positionY = savePosY - 1;
                            positionX = savePosX;
                            savePosY = positionY;
                        }
                        break;
                    case 1://diagonal right down
                        positionX++;
                        positionY++;
                        break;

                }
                arr[positionY, positionX] = i;

                if (currentStep == stepChange)
                {
                    direction++;
                    currentStep = 0;
                    stepChange++;
                }
            }

            PrintMatrix(arr);
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
