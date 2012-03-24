using System;
using System.IO;
using System.Linq;
using System.Text;

class ConcatFiles
{
    //Write a program that concatenates two text files into another text file.
    static void Main(string[] args)
    {
        StreamReader file1Reader = new StreamReader("..//..//Files/file_1.txt");
        StreamReader file2Reader = new StreamReader("..//..//Files/file_2.txt");

        StreamWriter writer = new StreamWriter("..//..//Files/concat_file.txt");
        
        string line = string.Empty;

        while (line != null)
        {
            line = file1Reader.ReadLine();
            if (!file1Reader.EndOfStream)
                writer.WriteLine(line);
        }

        file1Reader.Close();
        line = string.Empty;

        while (line != null)
        {
            line = file2Reader.ReadLine();
                writer.WriteLine(line);
        }
        file2Reader.Close();
        writer.Close();
    }
}