using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistinctLettersInString
{
    class Program
    {
        //Write a program that reads a string from the 
        //console and replaces all series of consecutive 
        //identical letters with a single one. 
        //Example: "aaaaabbbbbcdddeeeedssaa"  "abcdedsa".
        static void Main(string[] args)
        {
            string jj = "aaaaabbbbbcdddeeeedssaa";

            StringBla(jj);

            Console.WriteLine(newWord);
        }
        //TODO: NOT READY
        static string newWord = "";

        private static void StringBla(string word, int index =0, string temp = "")
        {

            for (int i = index; index < word.Length-1; i++)
            {
                index++;
                if (word[index] == word[index - 1] || word[index] == word[index + 1])
                {
                    StringBla(word, index, temp);
                }
                else
                {
                    newWord += word[index-1];
                    temp += word[index-1];
                }
            }
        }
    }
}