
using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

 

namespace Task2

{

    class Program

    {

        static StringBuilder sb = new StringBuilder();

        static int[][] digits =

            {

                new int[] {1, 1, 1, 1, 1, 1, 0},

                new int[] {0, 1, 1, 0, 0, 0, 0},

                new int[] {1, 1, 0, 1, 1, 0, 1},

                new int[] {1, 1, 1, 1, 0, 0, 1},

                new int[] {0, 1, 1, 0, 0, 1, 1},

                new int[] {1, 0, 1, 1, 0, 1, 1},

                new int[] {1, 0, 1, 1, 1, 1, 1},

                new int[] {1, 1, 1, 0, 0, 0, 0},

                new int[] {1, 1, 1, 1, 1, 1, 1},

                new int[] {1, 1, 1, 1, 0, 1, 1},

            };

        static void Main(string[] args)

        {

            string cInput;

            int numberOfLines;

            int totalComb = 0;

 

            cInput = Console.ReadLine();

            numberOfLines = Convert.ToInt32(cInput);

 

 

            for (int i = 0; i < numberOfLines; i++)

            {

                cInput = Console.ReadLine();

                totalComb = Combinations(cInput);

            }

            Console.WriteLine(totalComb);

            Console.WriteLine(sb);

        }

        static int Combinations(string vhod)

        {

            int[] inputArr = new int[vhod.Length];

            int numbComb;

            for (int i = 0; i < inputArr.Length; i++)

            {

                inputArr[i] = vhod[i] - '0';

            }

            numbComb = CheckCombinations(inputArr);

            for (int i = 0; i < inputArr.Length; i++)

            {

                if (inputArr[i] == 0)

                {

                    inputArr[i] = 1;

                    numbComb += CheckCombinations(inputArr);

                }

            }

            return numbComb;

        }

 

        static int CheckCombinations(int[] inputArr)

        {

            int numbComb = 0;

            int result = 0;

            for (int i = 0; i < digits.Length; i++)

            {

                for (int j = 0; j < digits[0].Length; j++)

                {

                    if (inputArr[j] == digits[i][j])

                    {

                        numbComb++;

                    }   

                }

                if (numbComb == 7)

                {

                    result++;

                    sb.Append(i);

                }

                numbComb = 0;

            }

            return result;

        }

    }

}