using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Brackets
{
    class Program
    {
        static string input;
        static char[] currentLoop;
        static List<string> list = new List<string>();

        static void GetBrackets(int loop)
        {
            if (loop == input.Length)
            {
                if (!list.Contains(new string(currentLoop)))
                {
                    list.Add(new string(currentLoop));
                }
                return;
            }

            for (int i = 1 + loop; i <= input.Length; i++)
            {
                if (input[i - 1] != '(' && input[i - 1] != ')')
                {
                    currentLoop[i - 1] = '(';
                    GetBrackets(i);
                    currentLoop[i - 1] = ')';
                    GetBrackets(i);
                }
                else
                {
                    currentLoop[i - 1] = input[i - 1];
                    if (i == input.Length)
                    {
                        if (!list.Contains(new string(currentLoop)))
                        {
                            list.Add(new string(currentLoop));
                        }
                    }
                }
            }
        }

        private static bool AreBracketsCorrect(string expression)
        {
            bool isValid = true;
            Stack<char> brackets = new Stack<char>();

            foreach (char ch in expression)
            {
                if (ch.Equals('('))
                {
                    brackets.Push(ch);
                }
                if (ch.Equals(')'))
                {
                    if (brackets.Count == 0)
                    {
                        isValid = false;
                        break;
                    }
                    brackets.Pop();
                }
            }

            if (isValid && brackets.Count != 0)
            {
                isValid = false;
            }

            return isValid;
        }

        static void Main(string[] args)
        {
            input = Console.ReadLine();
            currentLoop = new char[input.Length];
            GetBrackets(0);

            int counter = 0;
            foreach (var item in list)
            {
                if (AreBracketsCorrect(item))
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}