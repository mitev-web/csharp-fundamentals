using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brackets
{
    class Brackets
    {
        private static string sequence;
        private static int numberOfSequence = 0;
        private static int openBrackets = 0;
        private static int closingBrackets = 0;

        static void Main(string[] args)
        {
            sequence = Console.ReadLine();
            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] == '(')
                {
                    openBrackets++;
                }
                else if (sequence[i] == ')')
                {
                    closingBrackets++;
                }
            }
            findAllCombinations(sequence,openBrackets,closingBrackets);

            Console.WriteLine(numberOfSequence);
        }

        private static void findAllCombinations(string inputString,int open,int close)
        {
            int oBrackets = open;
            int cBrackets = close;
            for (int i = 0; i < inputString.Length; i++)
            {
                if (inputString[i] == '?')
                {
                    char[] inputArray = inputString.ToCharArray();
                    if ((oBrackets + 1) <= (inputString.Length / 2))
                    {
                        oBrackets++;
                        inputArray[i] = '(';
                        inputString = new string(inputArray);
                        findAllCombinations(inputString, oBrackets, cBrackets);
                        oBrackets--;
                    }
                    if (((cBrackets+1) <= (inputString.Length / 2)) && (i > 0))
                    {
                        cBrackets++;
                        inputArray[i] = ')';
                        inputString = new string(inputArray);
                        findAllCombinations(inputString, oBrackets, cBrackets);
                        cBrackets--;
                    }
                    return;
                }
            }
            checkSequenceValid(inputString);
        }

        private static void checkSequenceValid(string inputString)
        {
            System.Collections.Generic.Stack<char> brackets = new System.Collections.Generic.Stack<char>();
            for (int i = 0; i < inputString.Length; i++)
            {
                if (inputString[i] == '(')
                {
                    brackets.Push(inputString[i]);
                }
                else if (inputString[i] == ')')
                {
                    if (brackets.Count <= 0)
                    {
                        return;
                    }
                    brackets.Pop();
                }
            }
            if (brackets.Count == 0)
            {
                numberOfSequence++;
            }
        }
    }
}
