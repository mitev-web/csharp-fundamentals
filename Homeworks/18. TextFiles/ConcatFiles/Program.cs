using System;
using System.IO;
using System.Linq;
using System.Text;

namespace ConcatFiles
{
    class Program
    {
        //Write a program that concatenates two text files into another text file.

        private static string file1;
        private static string file2;
        static void Main(string[] args)
        {
            string filePath1 = "../../../file_1.txt";
            file1 = FileToString(filePath1);
            string filePath2 = "../../../file_2.txt";
            file2 = FileToString(filePath2);

            string concatFile = file1 + Environment.NewLine + file2;

            using (StreamWriter sw = new StreamWriter("../../../concat_file.txt"))
            {
                sw.Write(concatFile);
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
                }
            }

            return sb.ToString();
        }
    }
}