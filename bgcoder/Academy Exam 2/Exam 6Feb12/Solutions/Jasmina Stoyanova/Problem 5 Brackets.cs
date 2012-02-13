using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task03
{
    class Brackets
    {
        static bool AreBracketsCorrectlyPlaced(string expression)
        {
            bool areCorrectlyPlaced = false;
            int count = 0;

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    count++;
                }
                if (expression[i] == ')')
                {
                    count--;
                }

                if (count < 0)
                {
                    return areCorrectlyPlaced;
                }
            }

            if (count == 0)
            {
                areCorrectlyPlaced = true;
            }
            else
            {
                areCorrectlyPlaced = false;
            }
            
            return areCorrectlyPlaced;
        }

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int countCorrectness = 0;
            string inputExpression = input.Replace("?", ")");

            if (AreBracketsCorrectlyPlaced(inputExpression))
            {
                countCorrectness++;
            }

            Console.WriteLine(countCorrectness);
        }
    }
}
