using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace IntersectTextFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "../../../someText.txt";
            string text = FileToString(filePath);

            filePath = "../../../forbiddenWords.txt";
            string forbiddenWords = FileToString(filePath);

            string[] bannedWords = forbiddenWords.Split(' ');
            List<string> textWords = text.Split(' ').ToList();

            for(int i=0;i< textWords.Count;i++)
            {
                foreach (string banned in bannedWords)
                {
                    if (textWords.Contains(banned))
                    {
                        textWords.Remove(banned);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", textWords));



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
