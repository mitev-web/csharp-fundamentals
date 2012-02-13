using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task5Brackets
{
    class Program
    {
        static string pattern;
        static int open = 0;
        static int close = 0;
        static int counter = 0;

        static void Main(string[] args)
        {
            Input();

            Parse(pattern);

            Console.WriteLine(counter);
        }

        static void Input()
        {
            pattern = Console.ReadLine();
        }

        static void Parse(string expression)
        {
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] != '?') continue;
                StringBuilder sb = new StringBuilder(expression);
                sb[i] = '(';
                if (CheckBrackets(sb.ToString()))
                {
                    if (i == expression.Length - 1)
                    {
                        counter++;
                        return;
                    }
                    expression = sb.ToString();
                    Parse(expression);
                }
                else
                {
                    sb[i] = ')';
                    if (CheckBrackets(sb.ToString()))
                    {
                        if (i == expression.Length - 1)
                        {
                            counter++;
                            return;
                        }
                        expression = sb.ToString();
                        Parse(expression);
                    }
                }
            }
        }

        static bool CheckBrackets(string expression)
        {
            if (expression[0] == ')')
            {
                return false;
            }
            if (expression[expression.Length - 1] == '(')
            {
                return false;
            }

            int leftBrackets = 0;
            int rightBrackets = 0;

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == ')')
                {
                    rightBrackets++;
                    if (leftBrackets < rightBrackets)
                    {
                        return false;
                    }
                }
                else if (expression[i] == '(')
                {
                    leftBrackets++;
                }
            }

            if (leftBrackets != rightBrackets)
            {
                return false;
            }

            return true;
        }
    }
}
