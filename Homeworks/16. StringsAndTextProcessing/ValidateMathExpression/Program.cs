using System;
using System.Linq;

namespace ValidateMathExpression
{
    class Program
    {
//        Задачата става лесно с опашка, ако срещнеш отваряща скоба я вкараш в
//опашката, ако срещнеш затваряща проверяваш дали има нещо в опашката,
//ако няма хвърляш грешка, ако има махаш 1 елемент от опашката.

        static void Main(string[] args)
        {
            string expression = ")((a+b)/5-d))";

            bool hasOpenBracket = false;
            int bracketsCount = 0;
            for (int i = 0; i < expression.Length; i++)
            {
                if (!hasOpenBracket)
                {
                    if (expression[i] == '(')
                    {
                        hasOpenBracket = true;
                        bracketsCount++;
                    }
                    if (expression[i] == ')')
                    {
                        hasOpenBracket = true;
                        break;
                    }
                }
                else
                {
                    if (expression[i] == '(')
                    {
                        bracketsCount++;
                    }
                    if (expression[i] == ')')
                    {
                        bracketsCount--;
                    }
                    if (bracketsCount == 0)
                    {
                        hasOpenBracket = false;
                    }
                }
            }
            Console.WriteLine("Brackets are{0}correct.", hasOpenBracket ? " not " : " ");
        }
    }
}
