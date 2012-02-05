using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SortStrings
{
    class SortAndSave
    {
        //Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file. Example:
        static void Main(string[] args)
        {
            string filePath = "../../../names.txt";

            string text = FileToString(filePath);

            string[] lines = Regex.Split(text, "\n");

            lines = (from s in lines orderby s select s).ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var item in lines)
            {
                sb.Append(item);
            }
            string writeFilePath = "../../../ordered_names.txt";

            StringToFile(sb.ToString(), writeFilePath);
        }

        public static void StringToFile(string text, string writeFilePath)
        {
            using (StreamWriter sw = new StreamWriter(writeFilePath))
            {
                sw.Write(text);
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
                    sb.Append(Environment.NewLine);
                }
            }

            return sb.ToString();
        }
    }
}