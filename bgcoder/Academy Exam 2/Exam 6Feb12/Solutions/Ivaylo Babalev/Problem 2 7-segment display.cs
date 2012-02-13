using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
namespace _02._7_segment_Digits
{
    class Program
    {
        static int possibilitiesCounter = 0;
        static int allPossibilities = 1;
        static string[,] possibilities = new string[10, 2];
             
        static void Main(string[] args)
        {
            string[] digits = { "1111110", "0110000", "1101101", "1111001", "0110011", "1011011", "1011111", "1110000", "1111111", "1111011" };
 
            possibilities[0, 0] = "2";
            possibilities[0, 1] = "0 8";
            possibilities[1, 0] = "7";
            possibilities[1, 1] = "0 1 3 4 7 8 9";
            possibilities[2, 0] = "2";
            possibilities[2, 1] = "2 8";
            possibilities[3, 0] = "3";
            possibilities[3, 1] = "3 8 9";
            possibilities[4, 0] = "3";
            possibilities[4, 1] = "4 8 9";
            possibilities[5, 0] = "4";
            possibilities[5, 1] = "5 6 8 9";
            possibilities[6, 0] = "2";
            possibilities[6, 1] = "6 8";
            possibilities[7, 0] = "5";
            possibilities[7, 1] = "0 3 7 8 9";
            possibilities[8, 0] = "1";
            possibilities[8, 1] = "8";
            possibilities[9, 0] = "2";
            possibilities[9, 1] = "8 9";
 
 
            int n = int.Parse(Console.ReadLine());
            string[] numbers = new string[n];
            int[] decimalNumbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                numbers[i] = Console.ReadLine();
                for (int j = 0; j < digits.Length; j++)
                {
                    if (numbers[i] == digits[j])
                    {
                        decimalNumbers[i] = j;
                    }
                }
            }
 
            for (int i = 0; i < decimalNumbers.Length; i++)
            {
                string[] poss = possibilities[decimalNumbers[i], 1].Split();
                allPossibilities *= poss.Length;
            }
 
            Console.WriteLine(allPossibilities);
            GenerateDisplay(decimalNumbers, n, 0);
            Console.WriteLine();
        }
 
        static void GenerateDisplay(int[] decimalNumbers, int n, int i)
        {
            if (possibilitiesCounter >= allPossibilities)
            {
                return;
            }
            int j = 0;
            for (; i < n; i++)
            {
                if (i<0)
                {
                    return;
                }
                string[] poss = possibilities[decimalNumbers[i], 1].Split();
                for (; j < poss.Length; j++)
                {
                    int integer = int.Parse(poss[j]);
                    Console.Write(integer);
                    GenerateDisplay(decimalNumbers, n, i+1);
                    possibilitiesCounter++;
                    if (possibilitiesCounter >= allPossibilities)
                    {
                        return;
                    }
                    i--;
                    Console.WriteLine();
                    i--;
                }
            }
        }
    }
}