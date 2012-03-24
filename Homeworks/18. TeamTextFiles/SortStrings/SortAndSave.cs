using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class SortAndSave
{
    //Write a program that reads a text file containing a list of strings,
    //sorts them and saves them to another text file. Example:
    static void Main(string[] args)
    {
        List<string> words = new List<string>();
        StreamReader reader = new StreamReader("..//..//Files/unsorted.txt");
        StreamWriter writer = new StreamWriter("..//..//Files/sorted.txt");
        string line = "";
        using (reader)
        {
            line = reader.ReadLine();
            while (line != null)
            {
                words.Add(line);
               
                line = reader.ReadLine();
            }
        }
        words.Sort();
        using (writer)
        {
            for (int i = 0; i < words.Count; i++)
            {
                writer.WriteLine(words[i]);
            }
        }
    }
}