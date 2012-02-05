using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    //using part of code from http://www.dreamincode.net/forums/topic/207633-c%23-programming-challenge-palindromes/
    class ExtractPalindromes
    {
        static void Main(string[] args)
        {
            string text = "Abba, lamal. dsfsdf exE? alabala!";
            char[] separators = { ' ', '.', ',', '?', '!' };
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                if (ReverseAndCompare(word.ToLowerInvariant().ToCharArray()))
                {
                    Console.WriteLine(word);
                }
            }
        }
 
        public static bool ReverseAndCompare<T>(IEnumerable<T> sequence)
        {
            return sequence.SequenceEqual<T>(sequence.Reverse<T>());
        }
    }
}