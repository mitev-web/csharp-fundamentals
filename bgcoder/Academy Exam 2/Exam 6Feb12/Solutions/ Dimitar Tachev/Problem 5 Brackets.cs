using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task5
{
    class Program
    {
        static string text = null;
        static StringBuilder tempText = new StringBuilder();
        static List<string> result = new List<string>();
        static void Main(string[] args)
        {
            text = Console.ReadLine();
            tempText.Append(text);
            tempText[0] = '(';
            tempText[tempText.Length-1] = ')';
            text = tempText.ToString();
            if (tempText.Length%2==1)
            {
                Console.WriteLine(0);
                return;
            }
            FindPossibleParantesis(text);
            Console.WriteLine(result.Count);

        }
        private static void FindPossibleParantesis(string text)
        {
            tempText.Clear();
            tempText.Append(text);
            if (CheckParantesis(text))
            {
                if (!result.Contains(tempText.ToString()))
                {
                    result.Add(tempText.ToString());
                }
            }
            for (int i = 1; i < text.Length-1; i++)
            {
                if (text[i] == '?')
                {
                    tempText[i] = '(';
                    FindPossibleParantesis(tempText.ToString());
                    tempText[i] = ')';
                    FindPossibleParantesis(tempText.ToString());
                    tempText[i]= '?';
                }
            }
            return;
        }
        private static bool CheckParantesis(string str)
        {
            bool hasQ = false;
            int paranthesis = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '?')
                {
                    return false;
                }
                if (str[i] == '(')
                {
                    paranthesis++;
                }
                if (str[i] == ')')
                {
                    paranthesis--;
                }
                if (paranthesis < 0)
                {
                    return false;
                }
            }
            if (paranthesis != 0 || hasQ)
            {
                return false;
            }
            return true;
        }
    }
}
/*
????(?
*/