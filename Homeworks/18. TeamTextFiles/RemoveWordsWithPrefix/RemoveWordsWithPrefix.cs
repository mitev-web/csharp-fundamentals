using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class RemoveWordsWithPrefix
{
    //Write a program that deletes from a text file 
    //all words that start with the prefix "test". 
    //Words contain only the symbols 0...9, a...z, A…Z, _.
    static void Main(string[] args)
    {
        StreamReader reader = new StreamReader("..//..//Files/words_for_deletion.txt");
        string file = reader.ReadToEnd();
        reader.Close();
        file = Regex.Replace(file, @"test([A-Za-z0-9\-]+)", "");
        file = Regex.Replace(file, @"\btest\b", "");
        StreamWriter writer = new StreamWriter("..//..//Files/deleted_words.txt");
        writer.Write(file);
        writer.Close();
    }
}