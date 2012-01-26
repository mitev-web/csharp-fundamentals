using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReplaceString
{
    class Program
    {
        //We are given a string containing a list of forbidden words and a 
        //text containing some of these words. Write a program that 
        //replaces the forbidden words with asterisks. Example:
        //Microsoft announced its next generation PHP compiler today. It is based on 
        //.NET Framework 4.0 and is implemented as a dynamic language in CLR.


        //Words: "PHP, CLR, Microsoft"
        //The expected result:
        //********* announced its next generation *** compiler today. 
        //It is based on .NET Framework 4.0 and is implemented as a dynamic language in ***.



        static void Main(string[] args)
        {
            string text = "Microsoft announced its next generation PHP compiler today." +
                "It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";

            string[] forbiddenWords = {"Microsoft", "PHP", "CLR"};

            char replaceSymbol = '*';

            foreach (string word in forbiddenWords)
                text = text.Replace(word, CensourString(word.Length, replaceSymbol));

            Console.WriteLine(text);

        }

        public static string CensourString(int lenght, char c)
        {
            StringBuilder censor = new StringBuilder();

            for (int i = 0; i < lenght; i++)
            {
                censor.Append(c);
            }

            return censor.ToString();
        }
    }
}
