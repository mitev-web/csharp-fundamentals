using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2SevenSegmentDigits
{
    class Program
    {
        static int[] vector;
        static int[] numbers;
        static List<int[]> result = new List<int[]>();
        static int k;

        static void randNum(int position)
        {
            if (position == k)
            {
                int[] newVector = new int[k];
                for (int i = 0; i < k; i++)
                {
                    newVector[i] = vector[i];
                }
                result.Add(newVector);
            }
            else
            {
                switch(numbers[position])
                {
                    case 0:
                        int[] numbersZero = { 0, 8 };
                        for (int i = 0; i < numbersZero.Length; i++)
                        {
                            vector[position] = numbersZero[i];
                            randNum(position + 1);
                        }
                        break;
                    case 1:
                        int[] numbersOne = { 0, 1, 3, 4, 7, 8, 9 };
                        for (int i = 0; i < numbersOne.Length; i++)
                        {
                            vector[position] = numbersOne[i];
                            randNum(position + 1);
                        }
                        break;
                    case 2:
                        int[] numbersTwo = { 2,8 };
                        for (int i = 0; i < numbersTwo.Length; i++)
                        {
                            vector[position] = numbersTwo[i];
                            randNum(position + 1);
                        }
                        break;
                    case 3:
                        int[] numbersThree = { 3,8,9 };
                        for (int i = 0; i < numbersThree.Length; i++)
                        {
                            vector[position] = numbersThree[i];
                            randNum(position + 1);
                        }
                        break;
                    case 4:
                        int[] numbersFour = { 4,8,9 };
                        for (int i = 0; i < numbersFour.Length; i++)
                        {
                            vector[position] = numbersFour[i];
                            randNum(position + 1);
                        }
                        break;
                    case 5:
                        int[] numbersFive = { 5,6,8,9 };
                        for (int i = 0; i < numbersFive.Length; i++)
                        {
                            vector[position] = numbersFive[i];
                            randNum(position + 1);
                        }
                        break;
                    case 6:
                        int[] numbersSix = { 6,8 };
                        for (int i = 0; i < numbersSix.Length; i++)
                        {
                            vector[position] = numbersSix[i];
                            randNum(position + 1);
                        }
                        break;
                    case 7:
                        int[] numbersSeven = { 0,3,7,8,9 };
                        for (int i = 0; i < numbersSeven.Length; i++)
                        {
                            vector[position] = numbersSeven[i];
                            randNum(position + 1);
                        }
                        break;
                    case 8:
                        int[] numbersEight = { 8 };
                        for (int i = 0; i < numbersEight.Length; i++)
                        {
                            vector[position] = numbersEight[i];
                            randNum(position + 1);
                        }
                        break;
                    case 9:
                        int[] numbersNine = { 8,9 };
                        for (int i = 0; i < numbersNine.Length; i++)
                        {
                            vector[position] = numbersNine[i];
                            randNum(position + 1);
                        }
                        break;
                }
            }
        }

        static void PrintResult()
        {
            Console.WriteLine(result.Count);
            for (int i = 0; i < result.Count; i++ )
            {
                for (int j = 0; j < k; j++ )
                {
                    Console.Write(result[i][j]);
                }
                Console.WriteLine();
            }
        }


        static void Main(string[] args)
        {
            k = int.Parse(Console.ReadLine());
            vector = new int[k];
            numbers = new int[k];
            string[] lines = new string[k];
            for (int i = 0; i < k; i++ )
            {
                lines[i] = Console.ReadLine();
                if (lines[i] == "1111110")
                {
                    numbers[i] = 0;
                }
                if (lines[i] == "0110000")
                {
                    numbers[i] = 1;
                }
                if (lines[i] == "1101101")
                {
                    numbers[i] = 2;
                }
                if (lines[i] == "1111001")
                {
                    numbers[i] = 3;
                }
                if (lines[i] == "0110011")
                {
                    numbers[i] = 4;
                }
                if (lines[i] == "1011011")
                {
                    numbers[i] = 5;
                }
                if (lines[i] == "1011111")
                {
                    numbers[i] = 6;
                }
                if (lines[i] == "1110000")
                {
                    numbers[i] = 7;
                }
                if (lines[i] == "1111111")
                {
                    numbers[i] = 8;
                }
                if (lines[i] == "1111011")
                {
                    numbers[i] = 9;
                }
            }
            randNum(0);
            PrintResult();
        }
    }
}