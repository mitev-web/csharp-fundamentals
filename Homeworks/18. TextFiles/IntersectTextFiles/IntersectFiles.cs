using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace IntersectTextFiles
{
    class IntersectFiles
    {
        //Write a program that removes from a text 
        //file all words listed in given another text file. 
        //Handle all possible exceptions in your methods.

        static void Main(string[] args)
        {
            try
            {
                string filePath = "../../../someText.txt";
                string text = FileToString(filePath);

                filePath = "../../../forbiddenWords.txt";
                string forbiddenWords = FileToString(filePath);

                string[] bannedWords = forbiddenWords.Split(' ');
                List<string> textWords = text.Split(' ').ToList();

                for (int i = 0; i < textWords.Count; i++)
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