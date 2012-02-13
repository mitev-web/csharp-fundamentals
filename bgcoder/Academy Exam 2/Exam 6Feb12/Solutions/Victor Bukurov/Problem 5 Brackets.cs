using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brackets
{
    class Program
    {
        static int[,] emptySpaces;
        static int emptySpaceCounter;
        static int count = 0;
        static int leftBracketsCounter;
        static int rigthBracketsCounter;
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            //string input = "()(?";
            if (input.Length % 2 == 1)
            {
                Console.WriteLine(0);
                return;
            }
            emptySpaces = new int[input.Length, 2];
            emptySpaceCounter = 0;
            GetEmptySpaces(input);
            if (emptySpaceCounter > 0)
            {
                FindCombinations(0);
            }
            Console.WriteLine(count);
        }

        private static void FindCombinations(int index)
        {
            if (index == emptySpaceCounter)
            {
                if (rigthBracketsCounter == leftBracketsCounter)
                {
                    count++;
                }
                return;
            }

            if (leftBracketsCounter <= rigthBracketsCounter + emptySpaceCounter - index - 1)
            {
                leftBracketsCounter++;
                for (int i = index + 1; i < emptySpaceCounter; i++)
                {
                    emptySpaces[i, 0]++;
                }
                FindCombinations(index + 1);
                leftBracketsCounter--;
                for (int i = index + 1; i < emptySpaceCounter; i++)
                {
                    emptySpaces[i, 0]--;
                }
            }
            
            if (emptySpaces[index, 0] > emptySpaces[index, 1])
            {
                rigthBracketsCounter++;
                for (int i = index + 1; i < emptySpaceCounter; i++)
                {
                    emptySpaces[i, 1]++;
                }
                FindCombinations(index + 1);
                rigthBracketsCounter--;
                for (int i = index + 1; i < emptySpaceCounter; i++)
                {
                    emptySpaces[i, 1]--;
                }
            }
        }

        private static void GetEmptySpaces(string input)
        {
            leftBracketsCounter = 0;
            rigthBracketsCounter = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    leftBracketsCounter++;
                }
                else if (input[i] == ')')
                {
                    rigthBracketsCounter++;
                }
                else
                {
                    emptySpaces[emptySpaceCounter, 0] = leftBracketsCounter;
                    emptySpaces[emptySpaceCounter, 1] = rigthBracketsCounter;
                    emptySpaceCounter++;
                }
            }
        }
    }
}
