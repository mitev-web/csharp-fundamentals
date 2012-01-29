using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CountWords
{
    class Program
    {
        static void Main(string[] args)
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

            dict = (from s in dict orderby s.Value descending select s).ToDictionary(s => s.Key,
                s => s.Value);

            foreach (KeyValuePair<string, int> item in dict)
            {
                Console.WriteLine("The word {0} repeats {1} times", item.Key, item.Value);
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