using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task27SegmentDigits
{
    class Program
    {
        static int N;
        static string[] digits;
        static List<List<int>> possibleDigits = new List<List<int>>();
        static SortedDictionary<string, int> combinations = new SortedDictionary<string, int>();
        static string result = string.Empty;

        static void Main(string[] args)
        {
            Input();

            for (int i = 0; i < N; i++)
            {
                possibleDigits.Add(CheckForPossibleDigits(digits[i]));
            }

            FindCombinations(0);
            Print();
        }

        static void Input()
        {
            N = int.Parse(Console.ReadLine());
            digits = new string[N];
            for (int i = 0; i < N; i++)
            {
                digits[i] = Console.ReadLine();
            }
        }

        static List<int> CheckForPossibleDigits(string digit)
        {
            List<int> possibilities = new List<int>();

            if (!digit.Contains('0'))
            {
                possibilities.Add(8);
                return possibilities;
            }

            for (int i = 0; i < 7; i++)
            {
                if (digit[i] == '0')
                {
                    possibilities.Add(Translate(digit));
                    StringBuilder sb = new StringBuilder(digit);
                    sb[i] = '1';
                    possibilities.Add(Translate(sb.ToString()));
                }
            }

            return possibilities;
        }

        static int Translate(string digit)
        {
            if (digit == "1111110")
            {
                return 0;
            }

            if (digit == "0110000")
            {
                return 1;
            }

            if (digit == "1101101")
            {
                return 2;
            }

            if (digit == "1111001")
            {
                return 3;
            }

            if (digit == "0110011")
            {
                return 4;
            }

            if (digit == "1011011")
            {
                return 5;
            }

            if (digit == "1011111")
            {
                return 6;
            }

            if (digit == "1110000")
            {
                return 7;
            }

            if (digit == "1111111")
            {
                return 8;
            }

            if (digit == "1111011")
            {
                return 9;
            }
            
            return -1;
        }

        static void FindCombinations(int startIndex)
        {
            if (startIndex >= N)
            {
                if (!combinations.ContainsKey(result))
                {
                    combinations.Add(result, 1);
                }
                result = string.Empty;
                return;
            }

            //string result = string.Empty;
            for (int i = startIndex; i < possibleDigits.Count; i++)
            {
                List<int> possibilities = possibleDigits[i];
                for (int j = 0; j < possibilities.Count; j++)
                {
                    result += possibilities[j];
                    FindCombinations(startIndex + 1);
                }
            }
        }

        static void Print()
        {
            Console.WriteLine(combinations.Count);
            foreach (KeyValuePair<string, int> combo in combinations)
            {
                Console.WriteLine(combo.Key);
            }
        }
    }
}
