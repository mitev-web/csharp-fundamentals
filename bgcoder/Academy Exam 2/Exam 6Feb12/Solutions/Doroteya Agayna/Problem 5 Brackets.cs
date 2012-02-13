using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundamentalsExam2
{
    class Brackets
    {
        static string input = null;
        static char[] brackets = { '(', ')' };
        static int counter = 0;
        static StringBuilder sb;

        static void CheckCombination()
        {
            if (sb[sb.Length - 1] == '(')
            {
                return;
            }
            int i = 0, result = 0;
            for (i = 0; i < sb.Length; i++)
            {
                if (sb[i] == '(')
                {
                    result++;
                }
                else if (sb[i] == ')' && result > 0)
                {
                    result--;
                }
                else if (sb[i] == ')' && result == 0)
                {
                    break;
                }
            }
            if (i == sb.Length && result == 0)
            {
                counter++;
            }
        }

        static void GenerateString(int position)
        {
            if (sb[0] == ')')
            {
                return;
            }
            if (position == sb.Length)
            {
                CheckCombination();
            }
            else
            {
                if (input[position] == '?')
                {
                    for (int i = 0; i <= 1; i++)
                    {
                        sb[position] = brackets[i];
                        GenerateString(position + 1);
                    }
                }
                else
                {
                    position++;
                    GenerateString(position);
                }
            }
        }

        static void Main(string[] args)
        {
            input = Console.ReadLine();
            sb = new StringBuilder(input.Length);
            sb.Append(input);
            GenerateString(input.IndexOf('?'));
            Console.WriteLine(counter);
        }
    }
}