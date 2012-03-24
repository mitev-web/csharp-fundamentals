using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class InsertLineNumbers
{
    //Write a program that reads a text file and inserts 
    //line numbers in front of each of its lines. 
    //The result should be written to another text file.
    static void Main(string[] args)
    {
        string file1 = string.Empty;
        string filePath1 = "../../Files/file_1.txt";
        //we convert file to string and add line numbers
        file1 = FileToString(filePath1);

        StreamWriter sw = new StreamWriter("../../Files/linenumbers.txt");
        sw.Write(file1);
        sw.Close();
    }

    public static string FileToString(string filePath)
    {
        StringBuilder sb = new StringBuilder();

        using (StreamReader sr = new StreamReader(filePath))
        {
            string line;
            int counter = 1;
            while ((line = sr.ReadLine()) != null)
            {
                sb.Append(counter);
                sb.Append(". ");
                sb.Append(line);
                if (!sr.EndOfStream)
                    sb.Append(Environment.NewLine);
                counter++;
            }
        }

        return sb.ToString();
    }
}