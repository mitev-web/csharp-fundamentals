using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _7___Segments
{
    class Program
    {
        static readonly string[] digits =
        {
            "1111110",
            "0110000",
            "1101101",
            "1111001",
            "0110011",
            "1011011",
            "1011111",
            "1110000",
            "1111111",
            "1111011"
        };

        static List<int>[] possibleDigits;
        static List<string> possibleNumbers = new List<string>();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] inputs = new string[n];
            for (int i = 0; i < n; i++)
            {
                inputs[i] = Console.ReadLine();
            }
            PossibleDigits(inputs);
            PossibleNumbers();
            string[] numbers = possibleNumbers.OrderBy(x => x).ToArray();
            StringBuilder result = new StringBuilder(numbers.Length * 8 + 10);
            result.Append(numbers.Length + "\n");
            foreach (var item in numbers)
            {
                result.Append(item + "\n");
            }
            Console.WriteLine(result);
        }

        static void PossibleDigits(string[] inputs)
        {
            possibleDigits = new List<int>[inputs.Length];
            for (int i = 0; i < inputs.Length; i++)
            {
                possibleDigits[i] = new List<int>();
                for (int k = 0; k < digits.Length; k++)
                {
                    string digit = digits[k];
                    int countPossibleSegmets = 0;
                    for (int ch = 0; ch < digit.Length; ch++)
                    {
                        if (digit[ch] == '0' && inputs[i][ch] == '1')
                        {
                            break;
                        }
                        countPossibleSegmets++;
                    }
                    if (countPossibleSegmets == 7)
                    {
                        possibleDigits[i].Add(k);
                    }
                }
            }
        }

        static void PossibleNumbers()
        {
            for (int i = 0; i < possibleDigits[0].Count; i++)
            {
                StringBuilder number = new StringBuilder(8);
                number.Append(possibleDigits[0][i]);
                PutDigitInNumber(number, 1);
            }
        }

        static void PutDigitInNumber(StringBuilder number, int index)
        {
            if (index == possibleDigits.Length)
            {
                possibleNumbers.Add(number.ToString());
                return;
            }
            for (int i = 0; i < possibleDigits[index].Count; i++)
            {
                number.Append(possibleDigits[index][i]);
                PutDigitInNumber(number, index + 1);
                number.Remove(index, 1);
            }
        }
    }
}
