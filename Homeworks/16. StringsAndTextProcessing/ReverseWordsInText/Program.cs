using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReverseWordsInText
{
    class Program
    {
        //    Write a program that reverses the words in given sentence.
        //Example: "C# is not C++, not PHP and not Delphi!"
        //"Delphi not and PHP, not C++ not is C#!".

        static void Main(string[] args)
        {
            string sentence = "C# is not C++, not PHP and not Delphi!";

            Console.WriteLine(StringReverse(sentence.Split(' ')));

        }

        public static string StringReverse(string[] words)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = words.Length - 1; i >= 0; i--)
            {
                sb.Append(words[i]);
                sb.Append(" ");
            }
            return sb.ToString();
        }
    }
}
