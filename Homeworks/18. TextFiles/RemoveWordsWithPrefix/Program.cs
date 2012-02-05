using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class Program
{
    //Write a program that deletes from a text file 
    //all words that start with the prefix "test". 
    //Words contain only the symbols 0...9, a...z, A…Z, _.
    static void Main(string[] args)
    {
        string filePath = "../../../remove_starts_with_test.txt";
        string text = FileToString(filePath);

        List<string> words = text.Split(' ').ToList();

        for (int i = 0;i < words.Count;i++)
        {
            if (words[i].StartsWith("test") && words[i].Length > 4)
            {
                words.Remove(words[i]);
            }
        }
        text = string.Join(" ", words);
        Console.WriteLine(text);
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