using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CountWords
{
    class DictionaryOrder
    {
        //Write a program that reads a list of words from a file words.txt 
        //and finds how many times each of the words is contained in another
        //file test.txt. The result should be written in the file result.txt
        //and the words should be sorted by the number of their occurrences
        //in descending order. Handle all possible exceptions in your methods.
        static void Main(string[] args)
        {
            try
            {
                string filePath = "../../../words.txt";
                string[] words = FileToString(filePath).Split(' ').ToArray();
                filePath = "../../../test.txt";
                string[] test = FileToString(filePath).Split(new string[] { "\n" }, StringSplitOptions.None);

                Dictionary<string, int> dict = new Dictionary<string, int>();

                foreach (string word in words)
                {
                    foreach (string subWord in test)
                    {
                        if (word.Trim() == subWord.Trim())
                        {
                            if (dict.ContainsKey(word))
                            {
                                dict[word]++;
                            }
                            else
                            {
                                dict.Add(word, 1);
                            }
                        }
                    }
                }
               
                dict = (from s in dict
                        orderby s.Value descending
                        select s).ToDictionary(s => s.Key,
                    s => s.Value);

                foreach (KeyValuePair<string, int> item in dict)
                {
                    Console.WriteLine("The word {0} repeats {1} times", item.Key, item.Value);
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static string FileToString(string filePath)
        {
            StringBuilder sb = new StringBuilder();

            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    sb.Append(line);
                    if (!sr.EndOfStream)
                        sb.Append(Environment.NewLine);
                }
            }
            return sb.ToString();
        }
    }
}