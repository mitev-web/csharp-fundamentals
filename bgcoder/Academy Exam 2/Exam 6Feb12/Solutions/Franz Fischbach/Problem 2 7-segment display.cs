using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1.Variables
{
    class Program
    {
        // global variables
        static int[,] inputDigits;
        static int n;
        static int[,] solutions = new int[50000,18];
        static int solutionCount = 0;
        static  int[,] digits = new int[,]{
            {1,1,1,1,1,1,0}, //0
            {0,1,1,0,0,0,0}, //1
            {1,1,0,1,1,0,1}, //2
            {1,1,1,1,0,0,1}, //3
            {0,1,1,0,0,1,1}, //4
            {1,0,1,1,0,1,1}, //5
            {1,0,1,1,1,1,1}, //6
            {1,1,1,0,0,0,0}, //7
            {1,1,1,1,1,1,1}, //8
            {1,1,1,1,0,1,1}, }; //9

        //end global variables



        static bool IsDigitDisplayable(int digitToTest, int digitToTestFor)
        {
            for (int i = 0; i < 7; i++)
            {
                if (digits[digitToTestFor, i] < inputDigits[digitToTest,i])
                {
                    return false;
                }
            }

            return true;
        }

        static void CopyNumbToArrOfDigits(int digit, int position)
        {
            for (int i = 6; i >=0 ; i--)
            {
                inputDigits[position, i] = digit % 10;
                digit = digit / 10;
            }
        }

        static int[] ConvertNumbToArr(int digit)
        {
            int[] output = new int[7];

                for (int i = 6; i >=  0; i--)
                {
                    output[i] = digit % 10;
                    digit = digit / 10;
                }

            return output;
        }

        //static int ConvertArrDigit(int[] arr)
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        bool didNotBreack=true;

        //        for (int j = 0; j < 7; j++)
        //        {
        //            if (arr[j] != digits[i, j])
        //            {
        //                didNotBreack = false;
        //                break;
        //            }
        //        }
        //        if (didNotBreack) { return i; }
        //    }

        //    return -1; // error
        //}

        //static int ConvertArrToInt(int[] arr, int arrLenght)
        //{
        //    int number = 0;
        //    int coeficient = 1;

        //    for (int i = arrLenght-1; i >= 0; i--)
        //    {
        //        number = number + coeficient * arr[i];
        //    }

        //    return number;
        //}


        static void GenerateSolutions(int[] currentNumb,int progress)
        {
            if (progress == n)
            {
                solutionCount++;
                for (int i = 0; i < n; i++)
                {
                    solutions[solutionCount - 1, i] = currentNumb[i];
                }
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    if (IsDigitDisplayable(progress, i))
                    {
                        currentNumb[progress] = i;
                       // GenerateSolutions((int[])currentNumb.Clone(), progress + 1);
                        GenerateSolutions(currentNumb, progress + 1);
                    }

                }
            }

        }

        static void Main(string[] args)
        {
         
            n = int.Parse(Console.ReadLine());

            inputDigits = new int[n, 7];
            int rawInput = 0;

            for (int i = 0; i < n; i++)
            {
                rawInput = int.Parse(Console.ReadLine());
                CopyNumbToArrOfDigits(rawInput, i);
            }

            int[] currentNumb = new int[n];

            GenerateSolutions(currentNumb, 0);

            Console.WriteLine(solutionCount);

      //      StringBuilder str= new str
            char[] a = new char[128];

            for (int i = 0; i < solutionCount; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(solutions[i, j]);
                }
                Console.WriteLine();
            }


        }
    }
}
