using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistinctCount
{
    class CountDistinct
    {
        //Write a program that reads a string from
        //the console and lists all different words
        //in the string along with information 
        //how many times each word is found.
        static void Main(string[] args)
        {
            string text = "You are given a text. <upcase>Write a program that changes " +
                          "the text in all regions surrounded by the tags to uppercase.</upcase> ererer ";

            string[] words = text.Split(' ', '.', ',', '-', '?', '!');

            Dictionary<string, int> dict = new Dictionary<string, int>();

            foreach (string word in words)
            {
                int count;
                if (!dict.TryGetValue(word, out count))
                {
                    count = 0;
                }
                dict[word] = count + 1;
            }

            PrintWordOccurrenceCount(dict);
        }

        private static void PrintWordOccurrenceCount(
            IDictionary<string, int> wordOccuranceMap)
        {
            foreach (KeyValuePair<string, int> wordEntry
                in wordOccuranceMap)
            {
                Console.WriteLine(
                    "Word '{0}' occurs {1} time(s) in the text",
                    wordEntry.Key, wordEntry.Value);
            }

            Console.ReadKey();
        }
    }
}