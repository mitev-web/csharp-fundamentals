using System;



namespace Task01.D
{
    class Program
    {
        //Write a program that fills and prints a matrix of size (n, n) as shown below:
        //(examples for n = 4)

        //1 12  11 10
        //2 13  16  9
        //3 14  15  8
        //4  5  6   7

        static void Main(string[] args)
        {

            Console.WriteLine("Enter size of the matrix (N)");
            int N = new int();
            int.TryParse(Console.ReadLine(), out N);
            int[,] matrix = new int[N, N];

            PopulateMatrix(matrix);
            PrintMatrix(matrix);
        }

        private static void PopulateMatrix(int[,] matrix)
        {
            int positionX = 0;
            int positionY = -1;
            int N = matrix.GetLength(0);


            for (int i = 1; i < N+1; i++)
            {
                positionY++;
                matrix[positionY, positionX] = i;
            }


            int direction = 0;
            int currentStep = 0;
            int stepChange = N-1;


            for (int i = N+1; i <= N*N; i++)
            {
                currentStep++;

                switch (direction)
                {

                    case 0://right
                        positionX++;
                        break;
                    case 1://up
                        positionY--;
                        break;
                    case 2://left
                        positionX--;
                        break;
                    case 3://down
                        positionY++;
                        break;
                }


                if (currentStep == stepChange)
                {
                    currentStep = 0;
                    direction = ++direction % 4;

                    if (direction % 2 == 0)
                    {
                        stepChange--;
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
