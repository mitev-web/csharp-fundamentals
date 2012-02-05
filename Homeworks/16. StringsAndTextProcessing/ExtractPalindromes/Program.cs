using System;
using System.Linq;

namespace ExtractPalindromes
{
    class Program
    {
        //Write a program that extracts from a 
        //given text all palindromes, e.g. "ABBA", "lamal", "exe".
        static void Main(string[] args)
        {
            string text = "Also visit <a href=www.devbg.org>" +
                          " dd orum</a> to discuss ABA pesho@abv.bg the courses.</p> Also visit mary.ana@gmail.com <a href=www.devbg.org>" +
                          " our forum</a> andes1sedna seliandur@yahoo.com to fafa discuss affathe courses.</p>";
            string[] words = text.Split(' ');

            foreach (var item in words)
            {
                if(isPalindrome(item))
                    Console.WriteLine(item);
            }
        }

        public static bool isPalindrome(string word)
        {
            bool isPalindrome = true;

            for (int i = 0; i < word.Length / 2; i++)
            {
                if (word[i] != word[word.Length-1 - i])
                {
                    isPalindrome = false;
                }
            }
            return isPalindrome;
        }
    }
}